using UnityEngine;
using Status.Monobehaviours.Abstracts;
using Status.Interfaces;

namespace Status.Monobehaviours.Collectibles
{
    public class FuelCollectible : MonoBehaviour, ICollectible<AStatus>
    {
        [SerializeField] private float _fuelAmount;

        public void Collect(AStatus target)
        {
            target.Fuel.AddFuel(_fuelAmount);
        }

    }
}
