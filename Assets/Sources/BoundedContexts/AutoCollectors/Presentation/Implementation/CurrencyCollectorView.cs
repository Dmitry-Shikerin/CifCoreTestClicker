using Sources.BoundedContexts.AutoCollectors.Controllers;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.AutoCollectors.Presentation.Implementation
{
    public class CurrencyCollectorView: PresentableView<CurrencyAutoCollectorPresenter>, ICurrencyCollectorView
    {
        [SerializeField] private TextView _delayText;
        [SerializeField] private TextView _amountText;

        public ITextView DelayText => _delayText;
        public ITextView AmountText => _amountText;
    }
}