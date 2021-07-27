using UnityEngine;
using Interfaces.Level;
using Compositions.Enum;
using Compositions.Behaviours;

namespace Monobehaviours.BaseClasses
{
    public class Pod : MonoBehaviour, IPod
    {
        [SerializeField] protected PodType _podType;

        private IPod _podBehaviour;

        private void Awake()
        {
            switch (_podType)
            {
                case PodType.Launch:
                    _podBehaviour = new LaunchPod();
                    break;
                case PodType.Landing:
                    _podBehaviour = new LandingPod();
                    break;
            }
        }
    }
}
