using System;
using System.Threading;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.SofCurrencyPopUps.Infrastructure.Factories.Views;
using Sources.BoundedContexts.SofCurrencyPopUps.Presentation;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.Frameworks.Controllers.Implementation;

namespace Sources.BoundedContexts.Clickers.Controllers
{
    public class ClickerPresenter : PresenterBase
    {
        private readonly Energy _energy;
        private readonly SoftCurrency _softCurrency;
        private readonly IClickerView _view;
        private readonly SoftCurrencyPopUpViewFactory _softCurrencyPopUpViewFactory;
        private readonly SoftCurrencyPopUpView _prefab;

        private CancellationTokenSource _tokenSource;

        public ClickerPresenter(
            Energy energy,
            SoftCurrency softCurrency,
            IClickerView view,
            SoftCurrencyPopUpViewFactory softCurrencyPopUpViewFactory)
        {
            _energy = energy ?? throw new ArgumentNullException(nameof(energy));
            _softCurrency = softCurrency ?? throw new ArgumentNullException(nameof(softCurrency));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _softCurrencyPopUpViewFactory = softCurrencyPopUpViewFactory ?? throw new ArgumentNullException(nameof(softCurrencyPopUpViewFactory));
        }

        public override void Enable()
        {
            _view.ClickButton.AddClickListener(OnClick);
            _tokenSource = new CancellationTokenSource();
            OnAddedValueChanged();
            _softCurrency.AddedValueChanged += OnAddedValueChanged;
        }

        public override void Disable()
        {
            _view.ClickButton.RemoveClickListener(OnClick);
            _softCurrency.AddedValueChanged -= OnAddedValueChanged;
            _tokenSource.Cancel();
        }

        private void OnAddedValueChanged() =>
            _view.AddedCurrencyText.SetText(_softCurrency.SumAddedValue.ToString());

        private void OnClick()
        {
            if (_energy.TryTap() == false)
                return;

            _softCurrency.Increase();
            _softCurrencyPopUpViewFactory.Create(_softCurrency, _view);
        }
    }
}