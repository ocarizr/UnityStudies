using UnityEngine;
using Behaviours.Interfaces;
using Behaviours.Enum;
using Behaviours.Factories;

namespace Behaviours.Monobehaviours
{
    public class Pad : MonoBehaviour, IPad
    {
        [SerializeField] protected PadType _padType;

        private IPad _padBehaviour;

        private void Awake()
        {
            var builder = new PadBehaviourBuilder();
            builder.AddConfiguration(_padType);
            _padBehaviour = builder.Build();
        }
    }
}
