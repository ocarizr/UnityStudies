using UnityEngine;
using Monobehaviours.AbstractClass;

namespace Monobehaviours
{
    public class SpinnerBehaviour : AAIBehaviour
    {
        [SerializeField] private Vector3 _spinVelocity;

        protected override void Movement() => _movementEvent.Invoke(_spinVelocity);

        private void Start()
        {
            var randomYRot = Random.Range(0, 90);
            transform.rotation = Quaternion.Euler(0, randomYRot, 0);
            Movement();
        }
    }
}
