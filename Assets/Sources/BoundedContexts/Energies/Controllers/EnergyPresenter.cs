using System;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.Energies.Presentation.Interfaces;
using Sources.Frameworks.Controllers.Implementation;
using Sources.Frameworks.Utils;
using UnityEngine;

namespace Sources.BoundedContexts.Energies.Controllers
{
    public class EnergyPresenter : PresenterBase
    {
        private readonly Energy _energy;
        private readonly IEnergyView _view;

        public EnergyPresenter(
            Energy energy,
            IEnergyView view)
        {
            _energy = energy ?? throw new ArgumentNullException(nameof(energy));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _energy.ValueChanged += OnValueChanged;
        }

        public override void Disable()
        {
            _energy.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            float value = _energy.Value
                .IntToPercent(_energy.MaxValue)
                .IntPercentToUnitPercent();
            Debug.Log(value);
            
            _view.ImageView.SetFillAmount(value);
        }
    }
}