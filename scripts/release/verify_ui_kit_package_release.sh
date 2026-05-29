#!/usr/bin/env bash
set -euo pipefail
python3 - <<'PY'
from pathlib import Path
root = Path('/docker/chummercomplete/chummer-ui-kit')
manifest = root / 'README.md'
if not manifest.exists():
    raise SystemExit(f"missing ui-kit README: {manifest}")
text = manifest.read_text(encoding='utf-8', errors='ignore').lower()
for forbidden in ('httpclient', 'dbcontext', 'sqlconnection'):
    if forbidden in text:
        raise SystemExit(f"ui-kit README or package docs drift on forbidden token: {forbidden}")
print('ui-kit package release ok')
PY
