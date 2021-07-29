using UnityEngine;
using Interfaces.Level;
using Compositions.Enum;
using Compositions.Factories;

namespace Monobehaviours.BaseClasses
{
    public class Pad : MonoBehaviour, IPad
    {
        [SerializeField] protected PadType _padType;

        private IPad _padBehaviour;

        private void Awake()
        {
            _padBehaviour = PadBehaviourFactory.Build(_padType);
        }
    }
}
