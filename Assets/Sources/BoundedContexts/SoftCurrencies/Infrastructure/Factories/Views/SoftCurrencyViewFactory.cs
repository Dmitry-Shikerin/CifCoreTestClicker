using System;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Implementation;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Interfaces;

namespace Sources.BoundedContexts.SoftCurrencies.Infrastructure.Factories.Views
{
    public class SoftCurrencyViewFactory
    {
        private readonly SoftCurrencyPresenterFactory _presenterFactory;

        public SoftCurrencyViewFactory(SoftCurrencyPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ISoftCurrencyView Create(SoftCurrency softCurrency, SoftCurrencyView view)
        {
            var presenter = _presenterFactory.Create(softCurrency, view);
            view.Construct(presenter);

            return view;
        }
    }
}