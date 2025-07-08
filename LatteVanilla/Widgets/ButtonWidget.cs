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
        BorderColor.Set(VanillaTheme.ClickableBorderColor);
        BorderSize.Set(VanillaTheme.ClickableBorderSize);
        Radius.Set(VanillaTheme.ClickableBorderRadius);

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


    protected void StartDefaultAnimation()
    {
        _colorAnimation = VanillaTheme.AnimateProperty(Color, VanillaTheme.WidgetColor);
        _borderColorAnimation = VanillaTheme.AnimateProperty(BorderColor, VanillaTheme.ClickableBorderColor);
        _borderSizeAnimation = VanillaTheme.AnimateProperty(BorderSize, VanillaTheme.ClickableBorderSize);
    }

    protected void StartHoverAnimation()
    {
        _colorAnimation = VanillaTheme.AnimateProperty(Color, VanillaTheme.ClickableHoveredColor);
        _borderColorAnimation = VanillaTheme.AnimateProperty(BorderColor, VanillaTheme.ClickableHoveredBorderColor);
        _borderSizeAnimation = VanillaTheme.AnimateProperty(BorderSize, VanillaTheme.ClickableHoveredBorderSize);
    }

    protected void StartPressAnimation()
    {
        _colorAnimation = VanillaTheme.AnimateProperty(Color, VanillaTheme.ClickablePressedColor);
        _borderColorAnimation = VanillaTheme.AnimateProperty(BorderColor, VanillaTheme.ClickablePressedBorderColor);
        _borderSizeAnimation = VanillaTheme.AnimateProperty(BorderSize, VanillaTheme.ClickablePressedBorderSize);
    }


    public override void OnMouseEnter()
    {
        base.OnMouseEnter();

        StartHoverAnimation();
    }

    public override void OnMouseLeave()
    {
        base.OnMouseLeave();

        StartDefaultAnimation();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        StartPressAnimation();
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();

        StartHoverAnimation();
    }
}
