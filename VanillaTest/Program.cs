using SFML.Window;
using SFML.Graphics;

using Latte.Core.Type;
using Latte.Core.Application;
using Latte.Elements.Behavior;

using LatteVanilla;
using LatteVanilla.Widgets;



namespace Test;


class Program
{
    private static ButtonWidget NewButton(Alignment alignment)
        => new ButtonWidget(null, new Vec2f(), new Vec2f(130, 55), "Press")
        {
            Alignment = { Value = alignment }
        };


    static void Main(string[] args)
    {
        VanillaApp.Init(VideoMode.FullscreenModes[0], "Latte Vanilla", new Font("Fonts/NationalPark.ttf"), Styles.Default, new ContextSettings
        {
            AntialiasingLevel = 4
        });

        App.Debugger!.EnableKeyShortcuts = true;

        App.AddElement(NewButton(Alignment.TopLeft));
        App.AddElement(NewButton(Alignment.TopRight));
        App.AddElement(NewButton(Alignment.BottomLeft));
        App.AddElement(NewButton(Alignment.BottomRight));

        while (!App.ShouldQuit)
        {
            App.Update();
            App.Draw();
        }
    }
}
