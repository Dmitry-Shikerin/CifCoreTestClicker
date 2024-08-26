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
using Sources.BoundedContexts.Prefabs.Domain;
using Sources.BoundedContexts.SofCurrencyPopUps.Infrastructure.Factories.Views;
using Sources.BoundedContexts.SofCurrencyPopUps.Presentation;
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
                PrefabPath.SoftCurrencyConfig) as SoftCurrencyConfig;
            EnergyConfig energyConfig = await Resources.LoadAsync<EnergyConfig>(
                PrefabPath.EnergyConfig) as EnergyConfig;
            SoftCurrencyPopUpView softCurrencyPopUpView = 
                Resources.LoadAsync<SoftCurrencyPopUpView>(PrefabPath.SoftCurrencyPopUp)
                    .asset as SoftCurrencyPopUpView;
            
            SoftCurrency softCurrency = new SoftCurrency(config);
            Energy energy = new Energy(energyConfig);
            
            SoftCurrencyPopUpViewFactory softCurrencyPopUpViewFactory = 
                new SoftCurrencyPopUpViewFactory(softCurrencyPopUpView);
            
            ClickerPresenterFactory clickerPresenterFactory = 
                new ClickerPresenterFactory(softCurrencyPopUpViewFactory);
            ClickerViewFactory clickerViewFactory = new ClickerViewFactory(clickerPresenterFactory);
            clickerViewFactory.Create(energy, softCurrency, _hudView.ClickerView);
            
            CurrencyAutoCollectorPresenterFactory currencyAutoCollectorPresenterFactory = 
                new CurrencyAutoCollectorPresenterFactory();
            CurrencyCollectorViewFactory currencyCollectorViewFactory = 
                new CurrencyCollectorViewFactory(currencyAutoCollectorPresenterFactory);
            currencyCollectorViewFactory.Create(softCurrency, _hudView.CurrencyCollectorView);
            
            EnergyPresenterFactory energyPresenterFactory = new EnergyPresenterFactory();
            EnergyViewFactory energyViewFactory = new EnergyViewFactory(energyPresenterFactory);
            energyViewFactory.Create(energy, _hudView.EnergyView);
            
            SoftCurrencyPresenterFactory softCurrencyPresenterFactory = new SoftCurrencyPresenterFactory();
            SoftCurrencyViewFactory softCurrencyViewFactory = 
                new SoftCurrencyViewFactory(softCurrencyPresenterFactory);
            softCurrencyViewFactory.Create(softCurrency, _hudView.SoftCurrencyView);
        }
    }
}
