using Latte.Core.Animation;
using Latte.Core.Type;
using Latte.Elements;


namespace LatteVanilla;


public static class VanillaTheme
{
    public static readonly ColorRGBA Background = new ColorRGBA(255, 255, 255);

    public static readonly ColorRGBA WidgetColor = new ColorRGBA(230, 230, 230);

    public static readonly ColorRGBA SelectableHoveredColor = new ColorRGBA(215, 215, 215);
    public static readonly ColorRGBA SelectableBorderColor = new ColorRGBA(240, 240, 240, 100);
    public static readonly ColorRGBA SelectableHoveredBorderColor = new ColorRGBA(220, 220, 220, 100);

    public static readonly ColorRGBA TextDefaultColor = new ColorRGBA(50, 50, 50);
    public static readonly ColorRGBA TextHeaderColor = new ColorRGBA(35, 35, 35);

    public const float SelectableBorderSize = 3f;
    public const float SelectableHoveredBorderSize = 4f;
    public const float SelectableBorderRadius = 8f;

    public const float SelectableAnimationDuration = 0.3f;
    public const Easing SelectableAnimationEasing = Easing.EaseOutQuart;


    public static AnimationData AnimateProperty<T>(AnimatableProperty<T> property, T to) where T : IAnimatable<T>
        => property.Animate(to, SelectableAnimationDuration, SelectableAnimationEasing);
}
