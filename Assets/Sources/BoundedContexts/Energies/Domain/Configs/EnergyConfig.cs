using UnityEngine;

namespace Sources.BoundedContexts.Energies.Domain.Configs
{
    [CreateAssetMenu(fileName = "EnergyConfig", menuName = "Configs/EnergyConfig", order = 51)]
    public class EnergyConfig : ScriptableObject
    {
        [SerializeField] private int _maxValue = 100;
        [SerializeField] private int _energyForTap = 10;
        
        public int MaxValue => _maxValue;
        public int EnergyForTap => _energyForTap;
    }
}