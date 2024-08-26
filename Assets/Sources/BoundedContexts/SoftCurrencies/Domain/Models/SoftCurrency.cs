using System;
using Sources.BoundedContexts.SoftCurrencies.Domain.Configs;

namespace Sources.BoundedContexts.SoftCurrencies.Domain.Models
{
    public class SoftCurrency
    {
        private int _currentValue;
        private int _sumAddedValue;

        public SoftCurrency(SoftCurrencyConfig config)
        {
            BaseValue = config.BaseValue;
            Modifier = config.Modifier;
            SumIncome = config.SumIncome;
            Divider = config.Divider;
            Delay = config.Delay;
            AddedValue = config.AddedValue;
        }

        public event Action ValueChanged;
        public event Action AddedValueChanged;
        
        public int BaseValue { get; }
        public int Modifier { get; }
        public int SumIncome { get; }
        public int Divider { get; }
        public int Delay { get; }
        public int AddedValue { get; }

        public int SumAddedValue
        {
            get => _sumAddedValue;
            set
            {
                if (_sumAddedValue == value)
                    return;
                
                _sumAddedValue = value;
                AddedValueChanged?.Invoke();
            }
        }

        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                if (_currentValue == value)
                    return;
                
                _currentValue = value;
                ValueChanged?.Invoke();
            }
        }

        public void Increase()
        {
            CurrentValue += AddedValue;
        }
    }
}