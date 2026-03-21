# Package-Only Migration Evidence

Use this template to close:

`Migrate presentation and play to consume Chummer.Ui.Kit as a package-only dependency and delete duplicate local token/theme/component copies.`

## Required evidence per downstream repo

1. Package reference proof
- Repo:
- `Chummer.Ui.Kit` version:
- Commit SHA:

2. Duplicate-removal proof
- Deleted/replaced local token paths:
- Deleted/replaced local theme paths:
- Deleted/replaced local shared component paths:
- Commit SHA(s):

3. Guard proof
- CI job/check name:
- Guard command(s):
- Commit/path for guard wiring:

4. Verification proof
- Verify/build command(s) run:
- Link/reference to passing run:

## Submission block

```md
### Package-only migration evidence
- Repo: <repo>
- Date (UTC): <yyyy-mm-dd>
- Package version: <x.y.z>
- Package update commit: <sha>
- Local token copies removed:
  - <path>
- Local theme copies removed:
  - <path>
- Local shared component copies removed:
  - <path>
- Guard check: <command + ci path>
- Guard wiring commit: <sha>
- Verification commands: <command list>
- Passing run reference: <link or run id>
```

## Closure gate

The slice is complete only when both `chummer6-ui` and `chummer6-mobile` submit populated evidence blocks and link them from `WORKLIST.md`.
