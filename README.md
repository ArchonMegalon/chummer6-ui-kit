# chummer6-ui-kit

Shared design system package for Chummer6.

Current seed includes:

- token canon for UI-only design values
- theme compilation to CSS custom properties
- shell chrome, badges, banners, and accessibility primitives
- preview/gallery metadata kept inside `Chummer.Ui.Kit`

Excluded by design:

- domain DTOs
- HTTP clients
- rules math

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
5. Downstream adoption evidence gate:
   - Include proof for both `chummer6-ui` and `chummer6-mobile` before release closure.
