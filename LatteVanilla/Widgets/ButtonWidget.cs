using Latte.Core.Animation;
using Latte.Core.Type;
using Latte.Elements.Primitives;


namespace LatteVanilla.Widgets;


public class ButtonWidget : ButtonElement
{
    private AnimationData? _colorAnimation;
    private AnimationData? _borderColorAnimation;
    private AnimationData? _borderSizeAnimation;


    public ButtonWidget(Element? parent, Vec2f position, Vec2f size, string? text) : base(parent, position, size, text)
    {
        Color.Set(VanillaTheme.WidgetColor);
        BorderColor.Set(VanillaTheme.SelectableBorderColor);
        BorderSize.Set(VanillaTheme.SelectableBorderSize);
        Radius.Set(VanillaTheme.SelectableBorderRadius);

        Text?.Color.Set(VanillaTheme.TextDefaultColor);
        Text?.SizePolicyMargin.Set(new Vec2f(25));
    }


    public override void Update()
    {
        base.Update();

        UpdateAnimations();
    }


    private void UpdateAnimations()
    {
        _colorAnimation?.Update();
        _borderColorAnimation?.Update();
        _borderSizeAnimation?.Update();
    }


    public override void OnMouseEnter()
    {
        base.OnMouseEnter();

        _colorAnimation = VanillaTheme.AnimateProperty(Color, VanillaTheme.SelectableHoveredColor);
        _borderColorAnimation = VanillaTheme.AnimateProperty(BorderColor, VanillaTheme.SelectableHoveredBorderColor);
        _borderSizeAnimation = VanillaTheme.AnimateProperty(BorderSize, VanillaTheme.SelectableHoveredBorderSize);
    }

    public override void OnMouseLeave()
    {
        base.OnMouseLeave();

        _colorAnimation = VanillaTheme.AnimateProperty(Color, VanillaTheme.WidgetColor);
        _borderColorAnimation = VanillaTheme.AnimateProperty(BorderColor, VanillaTheme.SelectableBorderColor);
        _borderSizeAnimation = VanillaTheme.AnimateProperty(BorderSize, VanillaTheme.SelectableBorderSize);
    }
}
