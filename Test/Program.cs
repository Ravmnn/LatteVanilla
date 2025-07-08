using SFML.Window;
using SFML.Graphics;

using Latte.Core.Type;
using Latte.Core.Application;
using Latte.Elements;

using LatteVanilla;
using LatteVanilla.Widgets;



namespace Test;


class Program
{
    static void Main(string[] args)
    {
        VanillaApp.Init(VideoMode.FullscreenModes[0], "Latte Vanilla", new Font("Fonts/NationalPark.ttf"), Styles.Default, new ContextSettings
        {
            AntialiasingLevel = 4
        });
        
        App.Debugger!.EnableKeyShortcuts = true;

        var button = new ButtonWidget(null, new Vec2f(), new Vec2f(130, 55), "Press")
        {
            Alignment = { Value = Alignment.Center }
        };

        App.AddElement(button);

        while (!App.ShouldQuit)
        {
            App.Update();
            App.Draw();
        }
    }
}
