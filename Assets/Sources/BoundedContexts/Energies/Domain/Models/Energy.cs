using System;

namespace Sources.BoundedContexts.Energies.Domain
{
    public class Energy
    {
        private int _value;

        public Energy(int maxValue)
        {
            MaxValue = maxValue;
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