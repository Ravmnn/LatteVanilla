using SFML.Window;

using Latte.Animation;
using Latte.Application.Elements.Primitives;
using Latte.Core.Type;


namespace Latte.Vanilla.Widgets;


public class CheckBoxWidget : CheckBoxElement, IVanillaClickableAnimation
{
    public IVanillaClickableAnimation ThisVanillaAnimation => this;

    protected readonly FocusFrameWidget<CheckBoxWidget> FocusFrame;

    public AnimationData? ColorAnimation { get; set; }
    public AnimationData? BorderColorAnimation { get; set; }
    public AnimationData? BorderSizeAnimation { get; set; }


    public CheckBoxWidget(Element? parent, Vec2f? position, bool selected = false)
        : base(parent, position, selected)
    {
        FocusFrame = new FocusFrameWidget<CheckBoxWidget>(this);
    }


    public override void Update()
    {
        ThisVanillaAnimation.UpdateAnimations();

        base.Update();
    }


    public override void OnMouseEnter()
    {
        VanillaClickableAnimation.HoverAnimation(this);

        base.OnMouseEnter();
    }

    public override void OnMouseLeave()
    {
        if (!Focused)
            VanillaClickableAnimation.DefaultAnimation(this);

        base.OnMouseLeave();
    }

    public override void OnMouseDown()
    {
        VanillaClickableAnimation.PressAnimation(this);

        base.OnMouseDown();
    }

    public override void OnMouseUp()
    {
        VanillaClickableAnimation.HoverAnimation(this);

        base.OnMouseUp();
    }


    public override void OnFocus()
    {
        VanillaClickableAnimation.HoverAnimation(this);

        base.OnFocus();
    }

    public override void OnUnfocus()
    {
        VanillaClickableAnimation.DefaultAnimation(this);

        base.OnUnfocus();
    }


    public override void OnSubmitKeyDown(KeyEventArgs key)
    {
        VanillaClickableAnimation.DefaultAnimation(this);

        base.OnSubmitKeyDown(key);
    }

    public override void OnSubmitKeyUp(KeyEventArgs key)
    {
        VanillaClickableAnimation.HoverAnimation(this);

        base.OnSubmitKeyUp(key);
    }
}
