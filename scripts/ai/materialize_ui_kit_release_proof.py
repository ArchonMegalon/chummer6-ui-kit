#!/usr/bin/env python3
from __future__ import annotations

import argparse
import datetime as dt
import json
from pathlib import Path

UTC = dt.timezone.utc


def _iso_now() -> str:
    return dt.datetime.now(UTC).replace(microsecond=0).isoformat().replace("+00:00", "Z")


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Materialize UI kit local release proof artifact.")
    parser.add_argument("--repo-root", default="/docker/chummercomplete/chummer-ui-kit")
    parser.add_argument(
        "--out",
        default="/docker/chummercomplete/chummer-ui-kit/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json",
    )
    return parser.parse_args()


def main() -> int:
    args = parse_args()
    repo_root = Path(args.repo_root).resolve()
    out_path = Path(args.out).resolve()

    signoff_doc = repo_root / "docs" / "SHARED_SURFACE_SIGNOFF.md"
    adoption_doc = repo_root / "docs" / "u7-u8-release-adoption-evidence.md"
    verify_script = repo_root / "scripts" / "ai" / "verify.sh"

    status = "passed"
    reasons: list[str] = []

    if not signoff_doc.is_file():
        status = "failed"
        reasons.append("Missing shared-surface signoff document.")
    if not adoption_doc.is_file():
        status = "failed"
        reasons.append("Missing U7/U8 release adoption evidence document.")
    if not verify_script.is_file():
        status = "failed"
        reasons.append("Missing ui-kit verify lane script.")

    payload = {
        "contract_name": "chummer6-ui-kit.local_release_proof",
        "schema_version": 1,
        "generated_at": _iso_now(),
        "status": status,
        "repo_root": str(repo_root),
        "evidence": {
            "shared_surface_signoff_path": str(signoff_doc),
            "u7_u8_release_adoption_evidence_path": str(adoption_doc),
            "verify_script_path": str(verify_script),
        },
        "reasons": reasons,
    }

    out_path.parent.mkdir(parents=True, exist_ok=True)
    out_path.write_text(json.dumps(payload, indent=2, sort_keys=True) + "\n", encoding="utf-8")
    print(f"wrote ui-kit local release proof: {out_path}")
    return 0 if status == "passed" else 1


if __name__ == "__main__":
    raise SystemExit(main())
