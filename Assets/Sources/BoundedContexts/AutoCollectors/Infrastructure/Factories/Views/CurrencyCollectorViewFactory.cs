using System;
using Sources.BoundedContexts.AutoCollectors.Controllers;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.AutoCollectors.Presentation.Implementation;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Views
{
    public class CurrencyCollectorViewFactory
    {
        private readonly CurrencyAutoCollectorPresenterFactory _presenterFactory;

        public CurrencyCollectorViewFactory(CurrencyAutoCollectorPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }
        
        public ICurrencyCollectorView Create(
            SoftCurrency softCurrency, 
            CurrencyCollectorView view)
        {
            CurrencyAutoCollectorPresenter presenter = _presenterFactory.Create(softCurrency, view);
            view.Construct(presenter);
            
            return view;
        }
    }
}