using Chummer.Ui.Kit.Adapters;
using Chummer.Ui.Kit.Blazor.Adapters;

namespace Chummer.Ui.Kit.Downstream.Mobile;

public static class PinnedMobileCompatibilityContract
{
    public static UiAdapterPayload CompactShell()
        => BlazorUiKitAdapter.AdaptShellChrome(
            new ShellChrome("Title", "Body", ShellChromeTone.Focused, compact: true));

    public static UiAdapterPayload WarningBanner()
        => BlazorUiKitAdapter.AdaptBanner(
            new Banner("State", "Detail", BannerTone.Warning, pinned: true));
}
