using SFML.Window;
using SFML.Graphics;

using Latte.Core.Application;


namespace LatteVanilla;


// TODO: maybe create a constant for every default property? (radius, border width...)

// BUG: Latte's debug system not fully working: show bounds, priority, clip area... etc.


public static class VanillaApp
{
    public static void Init(VideoMode mode, string title, Font defaultFont, Styles styles, ContextSettings settings = default)
    {
        App.Init(mode, title, defaultFont, styles, settings);

        App.BackgroundColor = VanillaLightTheme.Background;
    }
}
