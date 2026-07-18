#!/usr/bin/env bash
set -euo pipefail
repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)"

python3 - "$repo_root" <<'PY'
import sys
from pathlib import Path

root = Path(sys.argv[1]).resolve()
manifest = root / 'README.md'
if not manifest.exists():
    raise SystemExit(f"missing ui-kit README: {manifest}")
text = manifest.read_text(encoding='utf-8', errors='ignore').lower()
for forbidden in ('httpclient', 'dbcontext', 'sqlconnection'):
    if forbidden in text:
        raise SystemExit(f"ui-kit README or package docs drift on forbidden token: {forbidden}")
print('ui-kit package release ok')
PY

bash "$repo_root/scripts/ai/verify_downstream_package_compatibility.sh"
