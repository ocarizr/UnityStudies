using Interfaces;
using Monobehaviours.BaseClass;
using System.Collections;
using UnityEngine;

namespace Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateAsMovementCommand : Command
    {
        private WaitForFixedUpdate _wait;

        private Rigidbody _rigidbody;
        private IMovement _input;
        private Coroutine _rotateCoroutine;

        [SerializeField] private bool _clockDirection;

        private void Awake()
        {
            _wait = new WaitForFixedUpdate();

            _rigidbody = GetComponent<Rigidbody>();
            _input = GetComponent<IMovement>();
            _rotateCoroutine = null;
        }

        private IEnumerator Rotate()
        {
            while (_input.MovementInput != Vector3.zero)
            {
                var currRot = _rigidbody.rotation.eulerAngles;
                var input = _input.MovementInput;
                var nextRot = Quaternion.Euler(_clockDirection ? 
                                                        currRot + input :
                                                        currRot - input);

                _rigidbody.MoveRotation(nextRot);
                yield return _wait;
            }

            _rotateCoroutine = null;
        }

        public override void Execute()
        {
            if(_rotateCoroutine == null)
            {
                _rotateCoroutine = StartCoroutine(Rotate());
            }
        }
    }
}
