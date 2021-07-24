using Interfaces;
using Monobehaviours.Manager;
using UnityEngine;

namespace Monobehaviours
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Obstacle : MonoBehaviour, IHittable
    {
        private MeshRenderer _renderer;

        [SerializeField] private int _score = 1;
        [SerializeField] private Material _hitMaterial;

        public bool IsHitted { get; private set; }

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        public void Hit()
        {
            if (!IsHitted)
            {
                _renderer.material = _hitMaterial;
                GameManager.GetInstance().AddScore(_score);
                IsHitted = true;
            }
        }
    }
}
