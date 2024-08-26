using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers
{
    public class ClickerPresenterFactory
    {
        public ClickerPresenter Create(
            Energy energy,
            SoftCurrency softCurrency,
            IClickerView view)
        {
            return new ClickerPresenter(energy, softCurrency, view);
        }
    }
}