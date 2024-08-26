using Sources.BoundedContexts.SoftCurrencies.Controllers;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Interfaces;

namespace Sources.BoundedContexts.SoftCurrencies.Infrastructure.Factories.Controllers
{
    public class SoftCurrencyPresenterFactory
    {
        public SoftCurrencyPresenter Create(SoftCurrency softCurrency, ISoftCurrencyView view)
        {
            return new SoftCurrencyPresenter(softCurrency, view);
        }
    }
}