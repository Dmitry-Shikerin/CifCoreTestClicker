using Sources.BoundedContexts.AutoCollectors.Controllers;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers
{
    public class CurrencyAutoCollectorPresenterFactory
    {
        public CurrencyAutoCollectorPresenter Create(SoftCurrency softCurrency, ICurrencyCollectorView view) =>
            new (softCurrency, view);
    }
}