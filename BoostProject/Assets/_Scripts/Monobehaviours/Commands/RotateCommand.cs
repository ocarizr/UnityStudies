using System.Collections;
using UnityEngine;
using Monobehaviours.Abstracts;
using Interfaces.Input;
using Compositions.BaseClasses;

namespace Monobehaviours.Commands
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateCommand : Command
    {
        private IRotateInput _input;
        private Rigidbody _rigidbody;
        private Coroutine _rotate;
        private WaitForFixedUpdate _waitForFixedUpdate;

        [SerializeField] private SpeedProperties _speedProperties;

        private void Awake()
        {
            _input = GetComponent<IRotateInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _rotate = null;
        }

        public override void Execute()
        {
            if (_rotate is null)
            {
                _rotate = StartCoroutine(Rotate());
            }
        }

        private IEnumerator Rotate()
        {
            var start = Time.time;
            while (_input.RotateInput != 0f)
            {
                var speed = _speedProperties.CalculateSpeed(start, _input.RotateInput);
                var nextRotation = GetNextRotation(speed);
                _rigidbody.MoveRotation(Quaternion.Euler(nextRotation));
                yield return _waitForFixedUpdate;
            }

            _rotate = null;
        }

        private Vector3 GetNextRotation(float speed)
        {
            var currRotation = _rigidbody.rotation.eulerAngles;
            var timeScaledSpeed = speed * Time.fixedDeltaTime;
            return currRotation + (Vector3.forward * timeScaledSpeed);
        }
    }
}
