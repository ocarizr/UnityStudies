using System;
using UnityEngine;

namespace CBehaviours.Compositions
{
    [Serializable]
    public class SpeedProperties
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] [Range(0, 1)] private float _rotateModifierRate;
        [SerializeField] private AnimationCurve _rotateModifier;

        public float CalculateSpeed(float startTime, float input)
        {
            var elapsed = Time.time - startTime;
            var curveIndex = Mathf.Clamp01(elapsed * _rotateModifierRate);
            return _rotateSpeed * _rotateModifier.Evaluate(curveIndex) * input;
        }
    }
}
