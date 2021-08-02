using UnityEngine;

namespace Status.Interfaces
{
    public interface ILayerMask
    {
        public LayerMask CanCollide { get; }
    }
}
