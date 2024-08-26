using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.AutoCollectors.Infrastructure.Factories.Views;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.Clickers.Infrastructure.Factories.Views;
using Sources.BoundedContexts.Energies.Domain.Configs;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.Energies.Infrastructures.Factories.Controllers;
using Sources.BoundedContexts.Energies.Infrastructures.Factories.Views;
using Sources.BoundedContexts.Huds.Presentation;
using Sources.BoundedContexts.SoftCurrencies.Domain.Configs;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Infrastructure.Factories.Controllers;
using Sources.BoundedContexts.SoftCurrencies.Infrastructure.Factories.Views;
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
            EnergyConfig energyConfig = await Resources.LoadAsync<EnergyConfig>(
                "Energies/EnergyConfig") as EnergyConfig;
            
            SoftCurrency softCurrency = new SoftCurrency(config);
            Energy energy = new Energy(energyConfig);
            
            //Clicker
            ClickerPresenterFactory clickerPresenterFactory = new ClickerPresenterFactory();
            ClickerViewFactory clickerViewFactory = new ClickerViewFactory(clickerPresenterFactory);
            clickerViewFactory.Create(energy, softCurrency, _hudView.ClickerView);
            
            //Collector
            CurrencyAutoCollectorPresenterFactory currencyAutoCollectorPresenterFactory = 
                new CurrencyAutoCollectorPresenterFactory();
            CurrencyCollectorViewFactory currencyCollectorViewFactory = 
                new CurrencyCollectorViewFactory(currencyAutoCollectorPresenterFactory);
            currencyCollectorViewFactory.Create(softCurrency, _hudView.CurrencyCollectorView);
            
            //Energy
            EnergyPresenterFactory energyPresenterFactory = new EnergyPresenterFactory();
            EnergyViewFactory energyViewFactory = new EnergyViewFactory(energyPresenterFactory);
            energyViewFactory.Create(energy, _hudView.EnergyView);
            
            //SoftCurrrency
            SoftCurrencyPresenterFactory softCurrencyPresenterFactory = new SoftCurrencyPresenterFactory();
            SoftCurrencyViewFactory softCurrencyViewFactory = 
                new SoftCurrencyViewFactory(softCurrencyPresenterFactory);
            softCurrencyViewFactory.Create(softCurrency, _hudView.SoftCurrencyView);
        }
    }
}
