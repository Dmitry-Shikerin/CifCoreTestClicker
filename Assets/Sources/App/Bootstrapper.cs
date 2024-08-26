using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Views;
using Sources.BoundedContexts.Huds.Presentation;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using UnityEngine;

namespace Sources.App
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private HudView _hudView;
        
        private void Start()
        {
            SoftCurrency softCurrency = new SoftCurrency();
            CurrencyCollector currencyCollector = new CurrencyCollector();
            
            ClickerPresenterFactory clickerPresenterFactory = new ClickerPresenterFactory();
            ClickerViewFactory clickerViewFactory = new ClickerViewFactory(clickerPresenterFactory);
            clickerViewFactory.Create(currencyCollector, softCurrency, _hudView.ClickerView);
        }
    }
}
