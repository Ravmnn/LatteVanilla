using Latte.Core.Animation;
using Latte.Core.Type;
using Latte.Elements;


namespace LatteVanilla;


public static class VanillaTheme
{
    public static readonly ColorRGBA Background = new ColorRGBA(255, 255, 255);

    public static readonly ColorRGBA WidgetColor = new ColorRGBA(230, 230, 230);

    public static readonly ColorRGBA SelectableBorderColor = new ColorRGBA(235, 235, 235, 100);
    public static readonly ColorRGBA SelectableHoveredColor = new ColorRGBA(215, 215, 215);
    public static readonly ColorRGBA SelectableHoveredBorderColor = new ColorRGBA(225, 225, 225, 100);
    public static readonly ColorRGBA SelectablePressedColor = new ColorRGBA(205, 205, 205);
    public static readonly ColorRGBA SelectablePressedBorderColor = new ColorRGBA(215, 215, 215, 100);

    public static readonly ColorRGBA TextDefaultColor = new ColorRGBA(50, 50, 50);
    public static readonly ColorRGBA TextHeaderColor = new ColorRGBA(35, 35, 35);

    public const float SelectableBorderRadius = 8f;
    public const float SelectableBorderSize = 3f;
    public const float SelectableHoveredBorderSize = 4.5f;
    public const float SelectablePressedBorderSize = 2.5f;

    public const float SelectableAnimationDuration = 0.25f;
    public const Easing SelectableAnimationEasing = Easing.EaseOutQuart;


    public static AnimationData AnimateProperty<T>(AnimatableProperty<T> property, T to) where T : IAnimatable<T>
        => property.Animate(to, SelectableAnimationDuration, SelectableAnimationEasing);
}
