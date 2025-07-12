using SFML.Window;

using Latte.Core.Animation;
using Latte.Core.Type;
using Latte.Elements.Primitives;
using Latte.Elements.Primitives.Shapes;


namespace LatteVanilla.Widgets;


public class ButtonWidget : ButtonElement
{
    private AnimationData? _colorAnimation;
    private AnimationData? _borderColorAnimation;
    private AnimationData? _borderSizeAnimation;

    private readonly RectangleElement _focusedFrame;


    public ButtonWidget(Element? parent, Vec2f position, Vec2f size, string? text) : base(parent, position, size, text)
    {
        _focusedFrame = new RectangleElement(this, new Vec2f(), new Vec2f())
        {
            Alignment = { Value = Latte.Elements.Behavior.Alignment.Center },

            Color = { Value = SFML.Graphics.Color.Transparent },
            BorderColor = { Value = VanillaTheme.ClickableFocusFrameColor },
            BorderSize = { Value = 3f },

            IgnoreMouseInput = true,

            Visible = false,
            Clip = false
        };

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

        UpdateFocusFrame();
        UpdateAnimations();
    }


    private void UpdateAnimations()
    {
        _colorAnimation?.Update();
        _borderColorAnimation?.Update();
        _borderSizeAnimation?.Update();
    }


    private void UpdateFocusFrame()
    {
        _focusedFrame.Radius.Set(Radius);
        _focusedFrame.Size.Set(GetBounds().Size + new Vec2f(3f, 3f));
        _focusedFrame.Visible = Focused;
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

        if (!Focused)
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


    public override void OnFocus()
    {
        base.OnFocus();

        StartHoverAnimation();
    }

    public override void OnUnfocus()
    {
        base.OnUnfocus();

        StartDefaultAnimation();
    }


    public override void OnSubmitKeyDown(KeyEventArgs key)
    {
        base.OnSubmitKeyDown(key);

        StartPressAnimation();
    }

    public override void OnSubmitKeyUp(KeyEventArgs key)
    {
        base.OnSubmitKeyUp(key);

        StartHoverAnimation();
    }
}
