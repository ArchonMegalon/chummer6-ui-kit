# Onboarding/Action Primitive Adoption Evidence

Use this evidence block to close:

`Queue Slice: Onboarding and long-running state primitives`  
`[queued] ui-kit: Add adoption and CI guard checks for new onboarding/action primitives in chummer6-ui and chummer6-mobile to prevent source-copy reintroduction.`

## Required evidence fields

- Repo: `chummer6-ui` or `chummer6-mobile`
- Date (UTC): `YYYY-MM-DD`
- Ui-kit package version consumed: `Chummer.Ui.Kit x.y.z`
- Guard check proof: command + guard pattern path showing fail-on-match coverage for:
  - `GuidanceState`
  - `LongRunningActionControls`
  - `AdaptGuidanceState(...)`
  - `AdaptLongRunningActionControls(...)`
- Queue linkage proof: local queue/worklist still points at package primitives rather than source-copy seams.
- Guard failure localization proof: guard scope is limited to actionable source roots (`Chummer.Presentation`/`Chummer.Blazor`/`Chummer.Avalonia`/`Chummer.Tests` for UI; `src` for mobile).

## Submitted evidence

### Onboarding/action primitive guard adoption evidence
- Repo: `chummer6-ui`
- Date (UTC): `2026-04-10`
- Ui-kit package version consumed: `0.1.0-preview`
- Guard check proof:
  - Command: `cd /docker/chummercomplete/chummer6-ui && bash scripts/ai/verify.sh`
  - Guard path: `scripts/ai/verify.sh`
  - Fail-on-match pattern now includes `GuidanceState|LongRunningActionControls` and `AdaptGuidanceState|AdaptLongRunningActionControls` in the package boundary scan.
- Queue linkage proof:
  - `WORKLIST.md` queue slice in `chummer6-ui-kit` maps onboarding and long-running state patterns to package-owned primitives and downstream implementation in `chummer6-ui`/`chummer6-mobile`.
- Guard failure localization proof:
  - Guard scan roots are `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, and `Chummer.Tests` only.

### Onboarding/action primitive guard adoption evidence
- Repo: `chummer6-mobile`
- Date (UTC): `2026-04-10`
- Ui-kit package version consumed: `0.1.0-preview`
- Guard check proof:
  - Command: `cd /docker/chummercomplete/chummer6-mobile && bash scripts/ai/verify.sh`
  - Guard path: `scripts/ai/verify.sh`
  - Fail-on-match pattern now includes `GuidanceState|LongRunningActionControls` and `AdaptGuidanceState|AdaptLongRunningActionControls` in the package boundary scan.
- Queue linkage proof:
  - `WORKLIST.md` queue slice in `chummer6-ui-kit` maps onboarding and long-running state patterns to package-owned primitives and downstream implementation in `chummer6-ui`/`chummer6-mobile`.
- Guard failure localization proof:
  - Guard scan root remains `src` only.
