using Latte.Animation;


namespace Latte.Vanilla.Widgets;


public interface IVanillaClickableAnimation
{
    public AnimationData? ColorAnimation { get; set; }
    public AnimationData? BorderColorAnimation { get; set; }
    public AnimationData? BorderSizeAnimation { get; set; }


    public void UpdateAnimations()
    {
        ColorAnimation?.Update();
        BorderColorAnimation?.Update();
        BorderSizeAnimation?.Update();
    }
}
