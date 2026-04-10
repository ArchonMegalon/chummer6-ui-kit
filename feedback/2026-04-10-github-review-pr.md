# GitHub Codex Review

PR: https://github.com/ArchonMegalon/chummer6-ui-kit/pull/8

Findings:
- [medium] src/Chummer.Ui.Kit/Tokens/TokenCanon.cs [contracts] long-running-no-loss-path-contract-drift
Token canon declares `long.running.actions.no.loss.default` as `safe-continuation` (kebab-case).; Avalonia adapter emits `no-loss-path` via `controls.NoLossPath.ToString()` which yields `SafeContinuation` (PascalCase).; Tests lock this drift by expecting `no-loss-path = SafeContinuation` and only asserting token alignment for the Blazor path.
Expected fix: Normalize Avalonia `no-loss-path` to the same contract casing as token canon (e.g., `safe-continuation`) and add explicit cross-adapter/token alignment assertions.
- [low] scripts/ai/verify.sh [review] verify-script-nondeterministic-tracked-artifact-write
`verify.sh` always invokes release-proof materialization and writes to a tracked file path.; Materialization includes `generated_at` from current time, so each verify run changes file content even without functional changes.
Expected fix: Make verify non-mutating (check mode or untracked output), or make the generated tracked artifact deterministic and only update during explicit publish flows.
