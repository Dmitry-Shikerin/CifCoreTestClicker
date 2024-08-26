using Sources.BoundedContexts.Energies.Controllers;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.Energies.Presentation.Interfaces;

namespace Sources.BoundedContexts.Energies.Infrastructures.Factories.Controllers
{
    public class EnergyPresenterFactory
    {
        public EnergyPresenter Create(Energy energy, IEnergyView view) =>
            new (energy, view);
    }
}