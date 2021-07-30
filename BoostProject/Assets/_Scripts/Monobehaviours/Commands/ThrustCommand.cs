using System.Collections;
using UnityEngine;
using Interfaces.Input;
using Monobehaviours.Abstracts;
using Compositions.BaseClasses;

namespace Monobehaviours.Commands
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThrustCommand : Command
    {
        private IThrustInput _input;
        private Rigidbody _rigidbody;
        private Coroutine _thrust;
        private WaitForFixedUpdate _waitForFixedUpdate;

        [SerializeField] private float _thrustForce;
        [SerializeField] private ThrustSound _thrustSound;

        private void Awake()
        {
            _input = GetComponent<IThrustInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _thrust = null;

            _waitForFixedUpdate = new WaitForFixedUpdate();
        }

        private IEnumerator Thrust()
        {
            _thrustSound.Play();
            while (_input.ThrustInput > 0f)
            {
                _rigidbody.AddRelativeForce(Vector3.up * _thrustForce, ForceMode.Force);
                yield return _waitForFixedUpdate;
            }

            _thrustSound.Stop();
            _thrust = null;
        }

        public override void Execute()
        {
            if (_thrust is null)
            {
                _thrust = StartCoroutine(Thrust());
            }
        }
    }
}
