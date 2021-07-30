using System;
using UnityEngine;
using Interfaces.Stats;

namespace Compositions.Behaviours
{
    [Serializable]
    public class FuelBehaviour : IFuelStats
    {
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _startFuel;
        [SerializeField] private float _consumptionMultiplier;
        [SerializeField] private AnimationCurve _consumptionRate;
        public float FuelAmount { get; private set; }
        public float ConsumptionMultiplier => _consumptionMultiplier;
        public AnimationCurve ConsumptionRate => _consumptionRate;

        public void Init() => FuelAmount = _startFuel;

        public void AddFuel(float amount) => UpdateFuel(amount);

        public void ConsumeFuel(float time)
        {
            var toConsume = GetAmountToConsume(time);
            UpdateFuel(-toConsume);
        }

        private float GetAmountToConsume(float time)
        {
            var scaledValue = time * ConsumptionMultiplier * Time.fixedDeltaTime;
            return ConsumptionRate.Evaluate(Mathf.Clamp01(scaledValue));
        }

        private void UpdateFuel(float amount) =>
            FuelAmount = Mathf.Clamp(FuelAmount + amount, 0f, _maxFuel);
    }
}
