using UnityEngine;
using Interfaces.Level;
using Compositions.Enum;
using Compositions.Behaviours;

namespace Monobehaviours.BaseClasses
{
    public class Pad : MonoBehaviour, IPad
    {
        [SerializeField] protected PadType _podType;

        private IPad _podBehaviour;

        private void Awake()
        {
            switch (_podType)
            {
                case PadType.Launch:
                    _podBehaviour = new LaunchPad();
                    break;
                case PadType.Landing:
                    _podBehaviour = new LandingPad();
                    break;
            }
        }
    }
}
