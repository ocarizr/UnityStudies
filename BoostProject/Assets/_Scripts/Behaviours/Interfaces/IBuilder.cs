namespace Behaviours.Interfaces
{
    public interface IBuilder<T, U>
    {
        T Configuration { get; }
        void AddConfiguration(T capability);
        U Build();
    }
}
