using UnityEngine;

namespace Sources.BoundedContexts.Energies.Domain.Configs
{
    [CreateAssetMenu(fileName = "EnergyConfig", menuName = "Configs/EnergyConfig", order = 51)]
    public class EnergyConfig : ScriptableObject
    {
        [SerializeField] private int _maxValue;
        
        public int MaxValue => _maxValue;
    }
}