using UnityEngine;
using Compositions.Behaviours;

namespace Status.Monobehaviours.Abstracts
{
    public abstract class AStatus : MonoBehaviour
    {
        [SerializeField] protected FuelBehaviour _fuel;
        [SerializeField] protected HealthBehaviour _health;

        public FuelBehaviour Fuel => _fuel;
        public HealthBehaviour Health => _health;

        private void OnEnable()
        {
            Fuel.Init();
            Health.Init();
        }
    }
}
