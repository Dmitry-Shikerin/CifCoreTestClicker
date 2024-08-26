using Sources.BoundedContexts.AutoCollectors.Controllers;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;

namespace Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers
{
    public class CurrencyAutoCollectorPresenterFactory
    {
        public CurrencyAutoCollectorPresenter Create(
            CurrencyCollector currencyCollector,
            ICurrencyCollectorView view)
        {
            return new CurrencyAutoCollectorPresenter(currencyCollector, view);
        }
    }
}