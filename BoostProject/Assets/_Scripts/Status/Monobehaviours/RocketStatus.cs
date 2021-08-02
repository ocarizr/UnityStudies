using UnityEngine;
using Status.Monobehaviours.Abstracts;
using Status.Interfaces;

namespace Status.Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketStatus : AStatus, ILayerMask
    {
        private Rigidbody _rigidbody;

        [SerializeField] private LayerMask _canCollide;
        [SerializeField] private float _safeVelocity;

        public LayerMask CanCollide => _canCollide;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var other = collision.gameObject;
            if (_canCollide == (_canCollide & 1 << other.layer))
            {
                var collectible = other.GetComponent<ICollectible<AStatus>>();
                if (collectible is { })
                {
                    collectible!.Collect(this);
                    return;
                }

                var velocity = _rigidbody.velocity;
                if (velocity.magnitude > _safeVelocity)
                {
                    _health.RemoveLife(_health.Lives);
                }

                return;
            }

            _health.RemoveLife(1);
        }
    }
}
