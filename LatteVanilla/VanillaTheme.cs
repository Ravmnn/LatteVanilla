using Latte.Animation;
using Latte.Core.Type;
using Latte.Application.Elements.Properties;


namespace Latte.Vanilla;


public static class VanillaTheme
{
    public static readonly ColorRGBA Background = new ColorRGBA(255, 255, 255);

    public static readonly ColorRGBA WidgetColor = new ColorRGBA(230, 230, 230);

    public static readonly ColorRGBA ClickableFocusFrameColor = new ColorRGBA(240, 230, 170);

    public static readonly ColorRGBA ClickableBorderColor = new ColorRGBA(235, 235, 235, 100);
    public static readonly ColorRGBA ClickableHoveredColor = new ColorRGBA(215, 215, 215);
    public static readonly ColorRGBA ClickableHoveredBorderColor = new ColorRGBA(225, 225, 225, 100);
    public static readonly ColorRGBA ClickablePressedColor = new ColorRGBA(205, 205, 205);
    public static readonly ColorRGBA ClickablePressedBorderColor = new ColorRGBA(215, 215, 215, 100);

    public static readonly ColorRGBA TextDefaultColor = new ColorRGBA(50, 50, 50);
    public static readonly ColorRGBA TextHeaderColor = new ColorRGBA(35, 35, 35);

    public const float ClickableBorderRadius = 8f;
    public const float ClickableBorderSize = 3f;
    public const float ClickableHoveredBorderSize = 4.5f;
    public const float ClickablePressedBorderSize = 2.5f;

    public const float ClickableAnimationDuration = 0.25f;
    public const Easing ClickableAnimationEasing = Easing.EaseOutQuart;


    public static AnimationData AnimateProperty<T>(AnimatableProperty<T> property, T to) where T : IAnimatable<T>
        => property.Animate(to, ClickableAnimationDuration, ClickableAnimationEasing);
}
