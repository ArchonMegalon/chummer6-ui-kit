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

python3 "$repo_root/scripts/ai/verify_package_hygiene.py" \
  --repo-root "$repo_root" \
  --manifest "$manifest"

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
  --nupkg "$nupkg"

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
