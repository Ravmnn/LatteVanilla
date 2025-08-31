using Latte.Animation;
using Latte.Application.Elements.Primitives.Shapes;
using Latte.Application.Elements.Properties;
using Latte.Vanilla.Widgets;


namespace Latte.Vanilla;


public static class VanillaClickableAnimation
{
    public static void DefaultAnimation<T>(T @object) where T : ShapeElement, IVanillaClickableAnimation
    {
        @object.ColorAnimation = AnimatePropertyOfClickable(@object.Color, VanillaStyle.WidgetColor);
        @object.BorderColorAnimation = AnimatePropertyOfClickable(@object.BorderColor, VanillaStyle.ClickableBorderColor);
        @object.BorderSizeAnimation = AnimatePropertyOfClickable(@object.BorderSize, VanillaStyle.ClickableBorderSize);
    }

    public static void HoverAnimation<T>(T @object) where T : ShapeElement, IVanillaClickableAnimation
    {
        @object.ColorAnimation = AnimatePropertyOfClickable(@object.Color, VanillaStyle.ClickableHoveredColor);
        @object.BorderColorAnimation = AnimatePropertyOfClickable(@object.BorderColor, VanillaStyle.ClickableHoveredBorderColor);
        @object.BorderSizeAnimation = AnimatePropertyOfClickable(@object.BorderSize, VanillaStyle.ClickableHoveredBorderSize);
    }

    public static void PressAnimation<T>(T @object) where T : ShapeElement, IVanillaClickableAnimation
    {
        @object.ColorAnimation = AnimatePropertyOfClickable(@object.Color, VanillaStyle.ClickablePressedColor);
        @object.BorderColorAnimation = AnimatePropertyOfClickable(@object.BorderColor, VanillaStyle.ClickablePressedBorderColor);
        @object.BorderSizeAnimation = AnimatePropertyOfClickable(@object.BorderSize, VanillaStyle.ClickablePressedBorderSize);
    }


    public static AnimationData AnimatePropertyOfClickable<T>(AnimatableProperty<T> property, T to) where T : IAnimatable<T>
        => property.Animate(to, VanillaStyle.ClickableAnimationDuration, VanillaStyle.ClickableAnimationEasing);
}
