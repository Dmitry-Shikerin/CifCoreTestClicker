using System;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Interfaces;
using Sources.Frameworks.Controllers.Implementation;

namespace Sources.BoundedContexts.SoftCurrencies.Controllers
{
    public class SoftCurrencyPresenter : PresenterBase
    {
        private readonly SoftCurrency _softCurrency;
        private readonly ISoftCurrencyView _view;

        public SoftCurrencyPresenter(
            SoftCurrency softCurrency,
            ISoftCurrencyView view)
        {
            _softCurrency = softCurrency ?? throw new ArgumentNullException(nameof(softCurrency));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            OnValueChanged();
            _softCurrency.ValueChanged += OnValueChanged;
        }

        public override void Disable()
        {
            _softCurrency.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            _view.AmountText.SetText(_softCurrency.CurrentValue.ToString());
        }
    }
}