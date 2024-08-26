using System;
using Sources.BoundedContexts.SoftCurrencies.Domain.Configs;
using Sources.Frameworks.Utils;

namespace Sources.BoundedContexts.SoftCurrencies.Domain.Models
{
    public class SoftCurrency
    {
        private readonly int _addedPercents;
        private readonly int _divider;
        private readonly int _modifier;
        private readonly int _baseValue;

        private int _currentValue;
        private int _sumAddedValue;

        public SoftCurrency(SoftCurrencyConfig config)
        {
            _baseValue = config.BaseValue;
            _modifier = config.Modifier;
            SumIncome = config.SumIncome;
            _divider = config.Divider;
            Delay = config.Delay;
            CollectorAddedValue = config.CollectorAddedValue;
            _addedPercents = config.AddedPercents;
        }

        public event Action ValueChanged;
        public event Action AddedValueChanged;

        public int SumIncome { get; }
        public int Delay { get; }
        public int CollectorAddedValue { get; }
        public int CurrentAddedValue => (_baseValue + _modifier) / _divider + SumAddedValue;

        public int SumAddedValue
        {
            get => _sumAddedValue;
            private set
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
            private set
            {
                if (_currentValue == value)
                    return;
                
                _currentValue = value;
                ValueChanged?.Invoke();
            }
        }

        public void Collect()
        {
            CurrentValue += CollectorAddedValue;
            SumAddedValue += CollectorAddedValue.GetValueFromPercent(_addedPercents);
        }

        public void Increase() =>
            CurrentValue += CurrentAddedValue;
    }
}