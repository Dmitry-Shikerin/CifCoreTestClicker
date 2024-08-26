using System;
using JetBrains.Annotations;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Implementation;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.Clickers.Infrastructure.Factories.Views
{
    public class ClickerViewFactory
    {
        private readonly ClickerPresenterFactory _presenterFactory;

        public ClickerViewFactory(ClickerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IClickerView Create(
            CurrencyCollector currencyCollector, 
            SoftCurrency softCurrency, 
            ClickerView view)
        {
            ClickerPresenter presenter = _presenterFactory.Create(currencyCollector, softCurrency, view);
            view.Construct(presenter);
            
            return view;
        }
    }
}