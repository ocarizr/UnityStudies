using UnityEngine;
using UnityEngine.Events;

namespace Monobehaviours.AbstractClass
{
    public abstract class AAIBehaviour : MonoBehaviour
    {
        protected UnityEvent<Vector3> _movementEvent = new UnityEvent<Vector3>();
        public void SubscribeToMovement(UnityAction<Vector3> action) => _movementEvent.AddListener(action);
        protected abstract void Movement();
    }
}
