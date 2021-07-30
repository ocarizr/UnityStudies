using UnityEngine;
using Interfaces.Level;
using Monobehaviours.Abstracts;

namespace Monobehaviours.Collectibles
{
    public class FuelCollectible : MonoBehaviour, ICollectible<Stats>
    {
        [SerializeField] private float _fuelAmount;

        public void Collect(Stats target)
        {
            target.Fuel.AddFuel(_fuelAmount);
        }

    }
}
