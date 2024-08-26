using Sources.Frameworks.Presentation.Components.Texts.Interfaces;

namespace Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces
{
    public interface ICurrencyCollectorView
    {
        ITextView DelayText { get; }
        ITextView AmountText { get; }
    }
}