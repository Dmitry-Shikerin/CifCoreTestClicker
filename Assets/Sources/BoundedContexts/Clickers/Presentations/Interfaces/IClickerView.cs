using Sources.Frameworks.Presentation.Components;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;

namespace Sources.BoundedContexts.Clickers.Presentations.Interfaces
{
    public interface IClickerView
    {
        ITextView AddedCurrencyText { get; }
        IButtonView ClickButton { get; }
    }
}