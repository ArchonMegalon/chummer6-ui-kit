# U4/U5 Centralization Adoption Evidence

Use this template to close the U4/U5 queue slice:

`Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)`

Auditor findings mapped: `487871`, `487874`

## Required evidence blocks

1. Package version consumed
- `Chummer.Ui.Kit` version in `chummer6-ui`:
- `Chummer.Ui.Kit` version in `chummer6-mobile`:
- Link(s) to package-bump commits:

2. Local-copy replacement proof (`chummer6-ui`)
- Paths where dense-data/explain/chummer-pattern local components were removed:
- Paths now consuming package primitives:
- Commit(s):

3. Local-copy replacement proof (`chummer6-mobile`)
- Paths where dense-data/explain/chummer-pattern local components were removed:
- Paths now consuming package primitives:
- Commit(s):

4. Guard checks (both repos)
- CI job/check name that blocks local reintroduction:
- Guard command(s):
- Link(s) to passing CI run(s):

5. Contract compatibility note
- Any payload/role/class key changes from prior local components:
- Confirmation that no domain DTO/service logic was introduced into UI-kit:

6. Verification linkage
- `scripts/ai/verify.sh` run in `chummer-ui-kit` for U4/U5 changes:
- Downstream verify/build command(s) run in `chummer6-ui` and `chummer6-mobile`:
- Link(s) to logs/artifacts:

## Closure gate

U4/U5 is ready to mark complete only when all six evidence blocks are populated for both downstream repos and linked back into `WORKLIST.md`.
