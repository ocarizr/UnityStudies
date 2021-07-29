using UnityEngine;
using Interfaces.Level;
using Compositions.Enum;
using Compositions.Factories;

using System;

namespace Monobehaviours.BaseClasses
{
    public class Pad : MonoBehaviour, IPad
    {
        [SerializeField] protected PadType _padType;

        private IPad _padBehaviour;

        private void Awake()
        {
            var builder = new PadBehaviourBuilder();
            builder.AddCapability(_padType);
            _padBehaviour = builder.Build();
        }
    }
}
