#!/usr/bin/env bash
set -euo pipefail
repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)"
dotnet_home="/tmp/chummer-ui-kit-dotnet"

mkdir -p "$dotnet_home"

export DOTNET_CLI_HOME="$dotnet_home"
export HOME="$dotnet_home"
export NUGET_PACKAGES="$dotnet_home/.nuget/packages"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1

test -f "$repo_root/docs/SHARED_SURFACE_SIGNOFF.md"
rg -n 'scripts/ai/verify\.sh|Blazor|Avalonia|accessibility|localization|performance|dotnet pack' \
  "$repo_root/docs/SHARED_SURFACE_SIGNOFF.md" >/dev/null
rg -n '84c56492|306f5bf3|f134092|6b57e12|0\.1\.0-preview|chummer6-ui|chummer6-mobile|drift status: `none`' \
  "$repo_root/docs/u7-u8-release-adoption-evidence.md" >/dev/null
rg -n '\[x\] `presentation` \+ `play`: Consume published package version and record deletion of source-copied UI primitives that the release replaces\.' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n '\[x\] `presentation` \+ `play`: Add/keep guard checks preventing reintroduction of repo-local copies for catalog-covered primitives\.' \
  "$repo_root/WORKLIST.md" >/dev/null

dotnet build "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" --nologo
dotnet build "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --nologo
dotnet pack "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" -c Release --nologo
dotnet run --project "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --no-build --nologo
python3 "$repo_root/scripts/ai/materialize_ui_kit_release_proof.py" \
  --repo-root "$repo_root" \
  --out "$repo_root/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json"
