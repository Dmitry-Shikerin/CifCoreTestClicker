using Sources.Frameworks.Presentation.Components.Texts.Interfaces;

namespace Sources.BoundedContexts.SoftCurrencies.Presentation.Interfaces
{
    public interface ISoftCurrencyView
    {
        ITextView AmountText { get; }
    }
}