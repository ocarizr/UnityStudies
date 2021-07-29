namespace Interfaces.Builders
{
    public interface IBuilder<T, U>
    {
        T Capability { get; }
        void AddCapability(T capability);
        U Build();
    }
}
