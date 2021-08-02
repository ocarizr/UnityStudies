using UnityEngine;
using Behaviours.Interfaces;
using Behaviours.Monobehaviours.Abstracts;

namespace Controllers.Monobehaviours.Abstracts
{
    public abstract class Controller : MonoBehaviour, IThrustInput, IRotateInput
    {
        [SerializeField]
        [Tooltip("Command with thrust logic")]
        protected Command _thrustCommand;

        [SerializeField]
        [Tooltip("Command with rotate logic")]
        protected Command _rotateCommand;

        public float ThrustInput { get; protected set; }
        public float RotateInput { get; protected set; }
    }
}
