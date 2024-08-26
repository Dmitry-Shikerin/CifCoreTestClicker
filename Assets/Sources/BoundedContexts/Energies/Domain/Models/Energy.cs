using System;
using Sources.BoundedContexts.Energies.Domain.Configs;

namespace Sources.BoundedContexts.Energies.Domain.Models
{
    public class Energy
    {
        private int _value;

        public Energy(EnergyConfig energyConfig)
        {
            MaxValue = energyConfig.MaxValue;
            Value = MaxValue;
            EnergyForTap = energyConfig.EnergyForTap;
        }

        public event Action ValueChanged;
        
        public int MaxValue { get; }
        public int EnergyForTap { get; }
        
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
            if (_value < EnergyForTap)
                return false;

            Value -= EnergyForTap;
            
            return true;
        }
    }
}