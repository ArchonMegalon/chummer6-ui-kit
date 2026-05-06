# ui-kit design

- Mission: define the repo boundary and package plane.
- Seed boundary: `Chummer.Ui.Kit` owns token canon, theme compilation, and preview/gallery manifests.
- Current shared primitives include shell/state affordances, dense-data adapters, long-running controls, and the milestone-121 action-budget, condition/effect, source-anchor, and Runboard payload contracts.
- Non-goals for this slice: domain DTOs, HTTP clients, or transport-layer abstractions.
