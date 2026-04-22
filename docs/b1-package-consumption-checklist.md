# B1 Package Consumption Checklist

Use this checklist when closing the shared token, shell chrome, and accessibility boundary for `chummer6-ui` and `chummer6-mobile`.

## Downstream actions

- `presentation`: replace repo-local shell chrome, banner, stale-state, approval, offline, and accessibility primitives with `Chummer.Ui.Kit`.
- `play`: replace repo-local shell chrome, banner, stale-state, approval, offline, and accessibility primitives with `Chummer.Ui.Kit`.
- `presentation` + `play`: add CI or guard checks that fail when repo-local copies of these B1 primitives are reintroduced.

## Evidence to capture

- Published `Chummer.Ui.Kit` package version consumed by each repo.
- Commit SHA in `chummer6-ui` that removes or replaces local B1 primitives.
- Commit SHA in `chummer6-mobile` that removes or replaces local B1 primitives.
- Path list for the deleted or migrated local primitives in each repo.
- Path to the guard check or CI rule that prevents source-copy regressions.

## Closure rule

Do not mark the B1 queue slice complete in this repo until both downstream repos provide package-adoption evidence and guard coverage.
