using System.Reflection;

using SFML.Window;

using Latte.Core;
using Latte.Core.Type;
using Latte.Application;
using Latte.Application.Elements.Behavior;

using Latte.Vanilla;
using Latte.Vanilla.Widgets;


namespace VanillaTest;


class Program
{
    private static ButtonWidget NewButton(Alignment alignment)
        => new ButtonWidget(null, new Vec2f(), new Vec2f(130, 55), "Press")
        {
            Alignment = { Value = alignment }
        };


    private static void Main(string[] args)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var font = assembly.LoadFont("VanillaTest.Fonts.NationalPark.ttf");

        VanillaApp.Init(new VideoMode(600, 400), "Latte Vanilla", font);

        App.Debugger!.EnableKeyShortcuts = true;

        var button = new ButtonWidget(null, null, null, "Confirm")
        {
            Alignment = { Value = Alignment.BottomRight },
            AlignmentMargin = { Value = new Vec2f(-10f, -10f) }
        };

        App.AddElement(button);

        while (!App.ShouldQuit)
        {
            App.Update();
            App.Draw();
        }
    }
}
