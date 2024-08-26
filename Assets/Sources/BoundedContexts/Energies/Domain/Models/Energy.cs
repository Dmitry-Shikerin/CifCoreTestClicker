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
        }

        public event Action ValueChanged;
        
        public int MaxValue { get; }
        
        public int Value
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;
                
                _value = value;
                ValueChanged?.Invoke();
            }
        }
    }
}