# ui-kit

Bootstrapped by Codex Fleet.

Current seed includes:

- token canon for UI-only design values
- theme compilation to CSS custom properties
- preview/gallery ownership metadata kept inside `Chummer.Ui.Kit`

Excluded by design:

- domain DTOs
- HTTP clients

## Release Discipline Gates (U8)

Do not cut or tag a `Chummer.Ui.Kit` release unless all gates pass.

1. `SemVer` gate:
   - `MAJOR`: breaking token key, adapter payload key, or preview manifest contract change.
   - `MINOR`: additive token, primitive, preview, or adapter payload field.
   - `PATCH`: docs/build/test/internal-only fixes with no public contract change.
2. Changelog gate:
   - Update release notes with contract-impact summary (tokens/adapters/previews changed or explicitly unchanged).
3. Packaging gate:
   - `dotnet pack src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj -c Release --nologo`
4. Verify gate:
   - `scripts/ai/verify.sh`
   - Standard release verify path (run both, in order):
     ```bash
     dotnet pack src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj -c Release --nologo
     scripts/ai/verify.sh
     ```
5. Downstream adoption evidence gate:
   - Include proof for both `chummer-presentation` and `chummer-play` before release closure.
   - Required fields:
     - repo name
     - consumed `Chummer.Ui.Kit` package version
     - removed local/source-copied UI paths
     - guard check path that prevents reintroduction
     - commit SHA containing the adoption update
   - Required evidence template:

| repo | package version | removed local/source-copied UI paths | guard check path | commit SHA |
| --- | --- | --- | --- | --- |
| `chummer-presentation` | `<version>` | `<path list>` | `<guard path/command>` | `<sha>` |
| `chummer-play` | `<version>` | `<path list>` | `<guard path/command>` | `<sha>` |
