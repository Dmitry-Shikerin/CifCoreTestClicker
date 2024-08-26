using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers
{
    public class ClickerPresenterFactory
    {
        public ClickerPresenter Create(
            CurrencyCollector currencyCollector, 
            SoftCurrency softCurrency,
            IClickerView view)
        {
            return new ClickerPresenter(currencyCollector, softCurrency, view);
        }
    }
}