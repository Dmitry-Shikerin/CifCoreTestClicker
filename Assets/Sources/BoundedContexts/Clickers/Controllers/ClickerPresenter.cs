using System;
using JetBrains.Annotations;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.Frameworks.Controllers.Implementation;
using UnityEngine;

namespace Sources.BoundedContexts.Clickers.Controllers
{
    public class ClickerPresenter : PresenterBase
    {
        private readonly CurrencyCollector _currencyCollector;
        private readonly SoftCurrency _softCurrency;
        private readonly IClickerView _view;

        public ClickerPresenter(
            CurrencyCollector currencyCollector,
            SoftCurrency softCurrency, 
            IClickerView view)
        {
            _currencyCollector = currencyCollector ?? throw new ArgumentNullException(nameof(currencyCollector));
            _softCurrency = softCurrency ?? throw new ArgumentNullException(nameof(softCurrency));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable() =>
            _view.ClickButton.AddClickListener(OnClick);

        public override void Disable() =>
            _view.ClickButton.RemoveClickListener(OnClick);

        private void OnClick()
        {
            Debug.Log($"Increase");
        }
    }
}