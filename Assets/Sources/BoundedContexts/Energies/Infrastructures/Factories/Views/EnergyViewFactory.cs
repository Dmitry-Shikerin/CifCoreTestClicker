using System;
using Sources.BoundedContexts.Energies.Controllers;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.Energies.Infrastructures.Factories.Controllers;
using Sources.BoundedContexts.Energies.Presentation.Implementation;
using Sources.BoundedContexts.Energies.Presentation.Interfaces;

namespace Sources.BoundedContexts.Energies.Infrastructures.Factories.Views
{
    public class EnergyViewFactory
    {
        private readonly EnergyPresenterFactory _presenterFactory;

        public EnergyViewFactory(EnergyPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IEnergyView Create(Energy energy, EnergyView view)
        {
            EnergyPresenter presenter = _presenterFactory.Create(energy, view);
            view.Construct(presenter);

            return view;
        }
    }
}