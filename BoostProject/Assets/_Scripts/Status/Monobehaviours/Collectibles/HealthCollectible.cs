using UnityEngine;
using Status.Monobehaviours.Abstracts;
using Status.Interfaces;

namespace Status.Monobehaviours.Collectibles
{
    public class HealthCollectible : MonoBehaviour, ICollectible<AStatus>
    {
        [SerializeField] private int _lifeAmount;

        public void Collect(AStatus target)
        {
            target.Health.AddLife(_lifeAmount);
        }
    }
}
