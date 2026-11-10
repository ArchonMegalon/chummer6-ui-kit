#!/usr/bin/env bash
set -euo pipefail
repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)"
# All four external inputs are required by the materializer. Missing evidence fails.
exec python3 "$repo_root/scripts/ai/materialize_ui_kit_release_proof.py" --check "$@"
