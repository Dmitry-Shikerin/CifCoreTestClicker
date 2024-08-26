using UnityEngine;

namespace Sources.BoundedContexts.SoftCurrencies.Domain.Configs
{
    [CreateAssetMenu(fileName = "SoftCurrencyConfig", menuName = "Configs/SoftCurrencyConfig", order = 51)]
    public class SoftCurrencyConfig : ScriptableObject
    {
        [Header("Tap Settings")]
        [SerializeField] private int _baseValue = 1;
        [SerializeField] private int _modifier = 1;
        [SerializeField] private int _sumIncome = 1;
        [SerializeField] private int _divider = 1;
        
        [Header("Auto Collect")]
        [SerializeField] private int _delay = 1;
        [SerializeField] private int _addedValue = 1;
        
        public int BaseValue => _baseValue;
        public int Modifier => _modifier;
        public int SumIncome => _sumIncome;
        public int Divider => _divider;
        
        public int Delay => _delay;
        public int AddedValue => _addedValue;
    }
}