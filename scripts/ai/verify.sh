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

dotnet build "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" --nologo
dotnet build "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --nologo
dotnet pack "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" -c Release --nologo
dotnet run --project "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --no-build --nologo
