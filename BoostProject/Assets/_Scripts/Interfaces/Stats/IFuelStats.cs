using UnityEngine;

namespace Interfaces.Stats
{
    public interface IFuelStats
    {
        float FuelAmount { get; }
        AnimationCurve ConsumptionRate { get; }
        float ConsumptionMultiplier { get; }
    }
}
