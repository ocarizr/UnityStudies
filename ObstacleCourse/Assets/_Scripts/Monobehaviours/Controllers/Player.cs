using AutoGenerated.Input;
using Interfaces;
using Monobehaviours.BaseClass;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : Controller
    {
        // Filter collision by layer
        private const string _layerName = "Ground";
        private int _layerMask;

        private ControllerInput _controller;

        private void OnMovement(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            MovementInput = new Vector3(value.x, 0, value.y);
            _movementCommand.Execute();
        }

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(_layerName);
            _controller = new ControllerInput();
        }

        private void OnEnable()
        {
            if (_movementCommand is { })
            {
                _controller.Controller.Movement.performed += OnMovement;
            }
            _controller.Enable();
        }

        private void OnDisable()
        {
            if (_movementCommand is { })
            {
                _controller.Controller.Movement.performed -= OnMovement;
            }
            _controller.Disable();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // If the other object is from the layers to ignore, ignore it
            if (_layerMask == (_layerMask | 1 << collision.gameObject.layer))
            {
                return;
            }

            var other = collision.gameObject.GetComponent<IHittable>();
            other?.Hit();
        }
    }
}
