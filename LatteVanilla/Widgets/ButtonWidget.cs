using Latte.Animation;
using Latte.Core.Type;
using Latte.Application.Elements.Primitives;
using Latte.Application.Elements.Primitives.Shapes;

using SFML.Window;


namespace Latte.Vanilla.Widgets;


public class ButtonWidget : ButtonElement
{
    private AnimationData? _colorAnimation;
    private AnimationData? _borderColorAnimation;
    private AnimationData? _borderSizeAnimation;

    private readonly RectangleElement _focusedFrame;


    public ButtonWidget(Element? parent, Vec2f position, Vec2f size, string? text) : base(parent, position, size, text)
    {
        // TODO: focus frame alignment is weird
        _focusedFrame = new RectangleElement(this, null, new Vec2f())
        {
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
        UpdateFocusFrame();
        UpdateAnimations();

        base.Update();
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
        StartHoverAnimation();

        base.OnMouseEnter();
    }

    public override void OnMouseLeave()
    {
        if (!Focused)
            StartDefaultAnimation();

        base.OnMouseLeave();
    }

    public override void OnMouseDown()
    {
        StartPressAnimation();

        base.OnMouseDown();
    }

    public override void OnMouseUp()
    {
        StartHoverAnimation();

        base.OnMouseUp();
    }


    public override void OnFocus()
    {
        StartHoverAnimation();

        base.OnFocus();
    }

    public override void OnUnfocus()
    {
        StartDefaultAnimation();

        base.OnUnfocus();
    }


    public override void OnSubmitKeyDown(KeyEventArgs key)
    {
        StartPressAnimation();

        base.OnSubmitKeyDown(key);
    }

    public override void OnSubmitKeyUp(KeyEventArgs key)
    {
        StartHoverAnimation();

        base.OnSubmitKeyUp(key);
    }
}
