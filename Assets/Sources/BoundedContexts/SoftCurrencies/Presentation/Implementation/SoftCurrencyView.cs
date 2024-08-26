using Sources.BoundedContexts.SoftCurrencies.Controllers;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Interfaces;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.SoftCurrencies.Presentation.Implementation
{
    public class SoftCurrencyView : PresentableView<SoftCurrencyPresenter>, ISoftCurrencyView
    {
        [SerializeField] private TextView _textView;

        public ITextView AmountText => _textView;
    }
}