using UnityEngine;
using Interfaces.Level;
using Monobehaviours.Abstracts;

namespace Monobehaviours.Collectibles
{
    public class HealthCollectible : MonoBehaviour, ICollectible<Stats>
    {
        [SerializeField] private int _lifeAmount;

        public void Collect(Stats target)
        {
            target.Health.AddLife(_lifeAmount);
        }
    }
}
