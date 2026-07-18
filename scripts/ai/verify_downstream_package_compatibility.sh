#!/usr/bin/env bash
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)"
manifest="$repo_root/tests/compatibility/downstream-pins.json"
package_project="$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj"
scratch_root="$(mktemp -d /tmp/chummer-ui-kit-package-compat.XXXXXX)"
trap 'rm -rf -- "$scratch_root"' EXIT

export DOTNET_CLI_HOME="$scratch_root/dotnet-cli"
export NUGET_PACKAGES="$scratch_root/nuget-packages"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export GIT_TERMINAL_PROMPT=0

python3 "$repo_root/scripts/ai/verify_package_hygiene.py" \
  --repo-root "$repo_root" \
  --manifest "$manifest"

mapfile -t authority_rows < <(
  python3 -c 'import json,sys; payload=json.load(open(sys.argv[1], encoding="utf-8")); [print("\t".join((item["id"], item["repository"], item["source_commit"]))) for item in payload["consumers"]]' "$manifest"
)
authority_args=()
for authority_row in "${authority_rows[@]}"; do
  IFS=$'\t' read -r consumer_id repository source_commit <<<"$authority_row"
  authority_repo="$scratch_root/authority-$consumer_id.git"
  git init --quiet --bare "$authority_repo"
  git --git-dir="$authority_repo" remote add origin "$repository"
  git --git-dir="$authority_repo" config core.repositoryFormatVersion 1
  git --git-dir="$authority_repo" config extensions.partialClone origin
  git --git-dir="$authority_repo" config remote.origin.promisor true
  git --git-dir="$authority_repo" config remote.origin.partialclonefilter blob:none
  git --git-dir="$authority_repo" fetch \
    --quiet \
    --no-tags \
    --depth=1 \
    --filter=blob:none \
    origin \
    "$source_commit"
  fetched_commit="$(git --git-dir="$authority_repo" rev-parse 'FETCH_HEAD^{commit}')"
  if [[ "$fetched_commit" != "$source_commit" ]]; then
    echo "authority acquisition returned $fetched_commit instead of $source_commit for $consumer_id" >&2
    exit 1
  fi
  authority_args+=(--authority-repo "$consumer_id=$authority_repo")
done

package_id="$(python3 -c 'import json,sys; print(json.load(open(sys.argv[1], encoding="utf-8"))["package"]["id"])' "$manifest")"
package_version="$(python3 -c 'import json,sys; print(json.load(open(sys.argv[1], encoding="utf-8"))["package"]["version"])' "$manifest")"
package_feed="$scratch_root/feed"
owner_packages="$scratch_root/owner-packages"
mkdir -p "$package_feed" "$owner_packages" "$DOTNET_CLI_HOME"

dotnet restore "$package_project" \
  --nologo \
  --packages "$owner_packages" \
  --source "$package_feed"
dotnet pack "$package_project" \
  -c Release \
  --no-restore \
  --nologo \
  --output "$package_feed" \
  -p:RestorePackagesPath="$owner_packages"

nupkg="$package_feed/$package_id.$package_version.nupkg"
test -f "$nupkg"
python3 "$repo_root/scripts/ai/verify_package_hygiene.py" \
  --repo-root "$repo_root" \
  --manifest "$manifest" \
  --nupkg "$nupkg" \
  "${authority_args[@]}"

for authority_row in "${authority_rows[@]}"; do
  IFS=$'\t' read -r consumer_id repository_unused source_commit <<<"$authority_row"
  echo "downstream authority verified: $consumer_id $source_commit"
done

mapfile -t compatibility_projects < <(
  python3 -c 'import json,sys; payload=json.load(open(sys.argv[1], encoding="utf-8")); [print(item["compatibility_project"]) for item in payload["consumers"]]' "$manifest"
)

for relative_project in "${compatibility_projects[@]}"; do
  fixture_project="$repo_root/$relative_project"
  fixture_id="$(basename "$(dirname "$relative_project")")"
  fixture_packages="$scratch_root/$fixture_id-packages"
  dotnet restore "$fixture_project" \
    --nologo \
    --no-cache \
    --packages "$fixture_packages" \
    --source "$package_feed"
  dotnet build "$fixture_project" \
    -c Release \
    --no-restore \
    --nologo \
    -p:RestorePackagesPath="$fixture_packages"
done

echo "downstream package compatibility: PASS ($package_id $package_version)"
