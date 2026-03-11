# ui-kit design

- Mission: define the repo boundary and package plane.
- Seed boundary: `Chummer.Ui.Kit` owns token canon, theme compilation, and preview/gallery manifests.
- Non-goals for this slice: domain DTOs, HTTP clients, or transport-layer abstractions.
