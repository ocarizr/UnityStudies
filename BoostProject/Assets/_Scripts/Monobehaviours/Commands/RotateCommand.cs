using System.Collections;
using UnityEngine;
using Interfaces.Input;
using Monobehaviours.Abstracts;

namespace Monobehaviours.Commands
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateCommand : Command
    {
        private IRotateInput _input;
        private Rigidbody _rigidbody;
        private Coroutine _rotate;
        private WaitForFixedUpdate _waitForFixedUpdate;

        [SerializeField] private float _rotateSpeed;
        [SerializeField] [Range(0, 1)] private float _rotateModifierRate;
        [SerializeField] private AnimationCurve _rotateModifier;

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
            var time = Time.time;
            while (_input.RotateInput != 0f)
            {
                var speed = CalculateSpeed(time);
                var nextRotation = GetNextRotation(speed);
                _rigidbody.MoveRotation(Quaternion.Euler(nextRotation));
                yield return _waitForFixedUpdate;
            }

            _rotate = null;
        }

        private float CalculateSpeed(float time)
        {
            var elapsed = Time.time - time;
            var curveIndex = Mathf.Clamp01(elapsed * _rotateModifierRate);
            return _rotateSpeed * _rotateModifier.Evaluate(curveIndex) * _input.RotateInput;
        }

        private Vector3 GetNextRotation(float speed)
        {
            var currRotation = _rigidbody.rotation.eulerAngles;
            var timeScaledSpeed = speed * Time.fixedDeltaTime;
            return currRotation + (Vector3.forward * timeScaledSpeed);
        }
    }
}
