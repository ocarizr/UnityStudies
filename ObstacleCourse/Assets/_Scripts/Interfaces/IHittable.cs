namespace Interfaces
{
    public interface IHittable
    {
        bool IsHitted { get; }
        void Hit();
    }
}
