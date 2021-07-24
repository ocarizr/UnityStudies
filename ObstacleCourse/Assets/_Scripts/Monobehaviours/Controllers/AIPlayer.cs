using Monobehaviours.AbstractClass;
using Monobehaviours.BaseClass;
using UnityEngine;
using UnityEngine.Events;

namespace Monobehaviours
{
    public class AIPlayer : Controller
    {
        private UnityAction<Vector3> _movementInputListener = null;

        [SerializeField] private AAIBehaviour _aiBehaviour;

        private void Awake() => _movementInputListener = MovementInputListener;

        private void OnEnable()
        {
            if (_aiBehaviour is null || _movementCommand is null) return;
            _aiBehaviour.SubscribeToMovement(_movementInputListener);
        }

        private void OnDisable()
        {
            if (_aiBehaviour is null || _movementCommand is null) return;
            _aiBehaviour.UnsubscribeToMovement(_movementInputListener);
        }

        private void MovementInputListener(Vector3 input)
        {
            MovementInput = input;
            _movementCommand!.Execute();
        }
    }
}
