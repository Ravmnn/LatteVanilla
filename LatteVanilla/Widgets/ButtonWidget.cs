using Latte.Core.Type;
using Latte.Elements.Primitives;


namespace LatteVanilla.Widgets;


public class ButtonWidget : ButtonElement
{
    public ButtonWidget(Element? parent, Vec2f position, Vec2f size, string? text) : base(parent, position, size, text)
    {
        Color.Set(VanillaLightTheme.Primary);
        BorderSize.Set(2);
        BorderColor.Set(VanillaLightTheme.Border);
        Radius.Set(13);

        Text?.Color.Set(VanillaLightTheme.TextDefault);
        Text?.SizePolicyMargin.Set(new Vec2f(25));
    }
}
