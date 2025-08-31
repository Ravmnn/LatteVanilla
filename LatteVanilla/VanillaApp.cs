using SFML.Window;
using SFML.Graphics;

using Latte.Application;


namespace Latte.Vanilla;


// TODO: add checkbox


public static class VanillaApp
{
    public static void Init(VideoMode mode, string title, Font defaultFont, Styles styles = Styles.Default, ContextSettings? settings = null)
    {
        App.Init(mode, title, defaultFont, styles, settings);

        App.BackgroundColor = VanillaTheme.Background;
    }
}
