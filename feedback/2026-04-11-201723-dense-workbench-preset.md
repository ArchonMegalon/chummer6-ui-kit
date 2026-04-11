# Dense workbench preset is release-blocking

Date: 2026-04-11
Audience: `chummer6-ui-kit`
Status: injected fleet feedback

## Summary

The flagship desktop density problem should be solved systematically in UI Kit, not one screen at a time in downstream UI code.

## Required changes

* Add a Chummer5a-familiar dense-workbench preset that covers:
  * top menu bar
  * toolstrip
  * dense tab strip
  * compact list/detail panes
  * compact inspector forms
  * permanent status strip
* Add a noise-budget token set for:
  * compact spacing
  * compact header scale
  * banner-height ceiling
  * badge-density ceiling
  * compact field and button heights
* Make this preset the default for flagship Avalonia screens.
* Add visual regression proof that measures dense workbench layouts rather than only generic shell polish.

## Guardrail

Accessibility improvements must not be implemented as blanket spaciousness or loud chrome.
This product is a power-user instrument and the flagship desktop preset must reflect that.
