using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Views;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Views;
using Sources.BoundedContexts.Huds.Presentation;
using Sources.BoundedContexts.SoftCurrencies.Domain.Configs;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using UnityEngine;

namespace Sources.App
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private HudView _hudView;
        
        private async void Start()
        {
            SoftCurrencyConfig config = await Resources.LoadAsync<SoftCurrencyConfig>(
                "Currencies/SoftCurrencyConfig") as SoftCurrencyConfig;
            
            SoftCurrency softCurrency = new SoftCurrency(config);
            CurrencyCollector currencyCollector = new CurrencyCollector();
            
            ClickerPresenterFactory clickerPresenterFactory = new ClickerPresenterFactory();
            ClickerViewFactory clickerViewFactory = new ClickerViewFactory(clickerPresenterFactory);
            clickerViewFactory.Create(currencyCollector, softCurrency, _hudView.ClickerView);
            
            CurrencyAutoCollectorPresenterFactory currencyAutoCollectorPresenterFactory = 
                new CurrencyAutoCollectorPresenterFactory();
            CurrencyCollectorViewFactory currencyCollectorViewFactory = 
                new CurrencyCollectorViewFactory(currencyAutoCollectorPresenterFactory);
            currencyCollectorViewFactory.Create(currencyCollector, _hudView.CurrencyCollectorView);
        }
    }
}
