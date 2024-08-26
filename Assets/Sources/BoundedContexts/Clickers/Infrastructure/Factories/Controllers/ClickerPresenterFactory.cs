using System;
using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.SofCurrencyPopUps.Infrastructure.Factories.Views;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;

namespace Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers
{
    public class ClickerPresenterFactory
    {
        private readonly SoftCurrencyPopUpViewFactory _softCurrencyPopUpViewFactory;

        public ClickerPresenterFactory(SoftCurrencyPopUpViewFactory softCurrencyPopUpViewFactory)
        {
            _softCurrencyPopUpViewFactory = softCurrencyPopUpViewFactory ?? 
                                            throw new ArgumentNullException(nameof(softCurrencyPopUpViewFactory));
        }

        public ClickerPresenter Create(Energy energy, SoftCurrency softCurrency, IClickerView view) =>
            new (energy, softCurrency, view, _softCurrencyPopUpViewFactory);
    }
}