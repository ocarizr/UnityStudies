using System;
using UnityEngine;
using Interfaces.Stats;

namespace Compositions.Behaviours
{
    [Serializable]
    public class HealthBehaviour : IHealthStats
    {
        [SerializeField] private int _startLife;
        [SerializeField] private int _maxLife;

        public int Lives { get; private set; }

        public void Init() => Lives = _startLife;
        public void AddLife(int life) => UpdateLife(life);
        public void RemoveLife(int life) => UpdateLife(-life);
        private void UpdateLife(int life) =>
            Lives = Mathf.Clamp(Lives + life, 0, _maxLife);
    }
}
