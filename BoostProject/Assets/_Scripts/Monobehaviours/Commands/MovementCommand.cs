using System.Collections;
using UnityEngine;
using Interfaces.Input;
using Monobehaviours.BaseClasses;

[RequireComponent(typeof(Rigidbody))]
public class MovementCommand : Command
{
    private IMovementInput _input;
    private Rigidbody _rigidbody;
    private Coroutine _move;

    private void Awake()
    {
        _input = GetComponent<IMovementInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _move = null;
    }

    private IEnumerator Move()
    {
        while (_input.MovementInput != Vector3.zero)
        {
            yield return null;
        }

        _move = null;
    }

    public override void Execute()
    {
        if (_move is null)
        {
            _move = StartCoroutine(Move());
        }
    }
}
