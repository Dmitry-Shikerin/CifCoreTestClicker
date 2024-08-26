using System;
using Sources.BoundedContexts.Energies.Domain.Configs;

namespace Sources.BoundedContexts.Energies.Domain.Models
{
    public class Energy
    {
        private readonly int _energyForTap;
        
        private int _value;

        public Energy(EnergyConfig energyConfig)
        {
            MaxValue = energyConfig.MaxValue;
            Value = MaxValue;
            _energyForTap = energyConfig.EnergyForTap;
        }

        public event Action ValueChanged;

        public int MaxValue { get; }

        public int Value
        {
            get => _value;
            private set
            {
                if (_value == value)
                    return;
                
                _value = value;
                ValueChanged?.Invoke();
            }
        }

        public bool TryTap()
        {
            if (_value < _energyForTap)
                return false;

            Value -= _energyForTap;
            
            return true;
        }
    }
}