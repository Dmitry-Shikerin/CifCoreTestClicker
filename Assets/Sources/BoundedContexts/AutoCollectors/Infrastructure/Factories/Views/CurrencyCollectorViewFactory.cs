using System;
using Sources.BoundedContexts.AutoCollectors.Controllers;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.AutoCollectors.Presentation.Implementation;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;

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
            CurrencyCollector currencyCollector, 
            CurrencyCollectorView view)
        {
            CurrencyAutoCollectorPresenter presenter = _presenterFactory.Create(currencyCollector, view);
            view.Construct(presenter);
            
            return view;
        }
    }
}