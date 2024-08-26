using Sources.BoundedContexts.AutoCollectors.Presentation.Implementation;
using Sources.BoundedContexts.Clickers.Presentations.Implementation;
using Sources.BoundedContexts.Energies.Presentation.Implementation;
using Sources.BoundedContexts.SoftCurrencies.Presentation.Implementation;
using Sources.Frameworks.Presentation;
using UnityEngine;

namespace Sources.BoundedContexts.Huds.Presentation
{
    public class HudView : View
    {
        [field: SerializeField] public ClickerView ClickerView { get; private set; }
        [field: SerializeField] public CurrencyCollectorView CurrencyCollectorView { get; private set; }
        [field: SerializeField] public EnergyView EnergyView { get; private set; }
        [field: SerializeField] public SoftCurrencyView SoftCurrencyView { get; private set; }
    }
}