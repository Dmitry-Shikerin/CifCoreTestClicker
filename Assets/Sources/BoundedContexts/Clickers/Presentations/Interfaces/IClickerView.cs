using Sources.Frameworks.Presentation.Components;

namespace Sources.BoundedContexts.Clickers.Presentations.Interfaces
{
    public interface IClickerView
    {
        IButtonView ClickButton { get; }
    }
}