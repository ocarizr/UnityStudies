using UnityEngine;
using Interfaces.Input;

namespace Monobehaviours.BaseClasses
{
    public class Controller : MonoBehaviour, IMovementInput
    {
        [SerializeField]
        [Tooltip("Command with movement logic")]
        protected Command _movementCommand;

        public Vector3 MovementInput { get; protected set; }
    }
}
