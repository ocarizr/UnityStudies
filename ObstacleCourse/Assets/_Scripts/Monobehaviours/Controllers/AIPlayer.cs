using UnityEngine;
using Monobehaviours.BaseClass;
using Monobehaviours.AbstractClass;

namespace Monobehaviours
{
    public class AIPlayer : Controller
    {
        [SerializeField] private AAIBehaviour _aiBehaviour;

        private void Awake()
        {
            if(_aiBehaviour)
            {
                _aiBehaviour.SubscribeToMovement(MovementInputListener);
            }
        }

        private void MovementInputListener(Vector3 input)
        {
            MovementInput = input;
            _movementCommand?.Execute();
        }
    }
}
