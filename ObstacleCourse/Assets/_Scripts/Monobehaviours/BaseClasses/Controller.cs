using Interfaces;
using UnityEngine;

namespace Monobehaviours.BaseClass
{
    public class Controller : MonoBehaviour, IMovement
    {
        public Vector3 MovementInput { get; protected set; }

        [SerializeField] protected Command _movementCommand;
    }
}
