using Latte.Core.Type;
using Latte.Application.Elements.Behavior;
using Latte.Application.Elements.Primitives;
using Latte.Application.Elements.Primitives.Shapes;


namespace Latte.Vanilla.Widgets;


public class FocusFrameWidget<TParent> : RectangleElement
    where TParent : Element, IClickable
{
    public new TParent Parent => (base.Parent as TParent)!;


    public FocusFrameWidget(TParent? parent)
        : base(parent, null, new Vec2f())
    {
        Color.Set(SFML.Graphics.Color.Transparent);
        BorderColor.Set(VanillaStyle.ClickableFocusFrameColor);

        BorderSize.Set(3f);

        IgnoreMouseInput = true;
        Visible = false;
        Clip = false;
    }


    public override void ConstantUpdate()
    {
        UpdateGeometry();

        base.ConstantUpdate();
    }


    private void UpdateGeometry()
    {
        if (Parent is RectangleElement rect)
            Radius.Set(rect.Radius);

        Size.Set(Parent.GetBounds().Size + VanillaStyle.FocusFrameInnerSize);
        Visible = Parent.Focused;
    }
}
