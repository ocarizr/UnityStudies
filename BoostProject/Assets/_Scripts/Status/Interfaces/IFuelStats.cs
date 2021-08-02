using UnityEngine;

namespace Status.Interfaces
{
    public interface IFuelStats
    {
        float FuelAmount { get; }
        AnimationCurve ConsumptionRate { get; }
        float ConsumptionMultiplier { get; }
    }
}
