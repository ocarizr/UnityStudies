using UnityEngine;

namespace Interfaces.Level
{
    public interface ILayerMask
    {
        public LayerMask CannotCollide { get; }
        public LayerMask CanCollide { get; }
    }
}
