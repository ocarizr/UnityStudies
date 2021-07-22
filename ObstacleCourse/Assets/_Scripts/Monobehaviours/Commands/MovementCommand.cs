using Interfaces;
using Monobehaviours.BaseClass;
using System.Collections;
using UnityEngine;

namespace Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementCommand : Command
    {
        private WaitForFixedUpdate _wait;

        private Rigidbody _rigidbody;
        private IMovement _movementInput;
        private Coroutine _moveCoroutine;

        [SerializeField] [Range(0, 20)] private int _speed;

        private void Awake()
        {
            _wait = new WaitForFixedUpdate();

            _rigidbody = GetComponent<Rigidbody>();
            _movementInput = GetComponent<IMovement>();
            _moveCoroutine = null;
        }

        private IEnumerator Move()
        {
            while (_movementInput.MovementInput != Vector3.zero)
            {
                var speed = Time.fixedDeltaTime * _speed;
                _rigidbody.MovePosition(transform.position + (_movementInput.MovementInput * speed));
                yield return _wait;
            }

            _moveCoroutine = null;
        }

        public override void Execute()
        {
            if (_moveCoroutine == null)
            {
                _moveCoroutine = StartCoroutine(Move());
            }
        }
    }
}
