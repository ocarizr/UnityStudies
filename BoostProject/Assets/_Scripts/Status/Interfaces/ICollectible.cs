namespace Status.Interfaces
{
    public interface ICollectible<T> where T : class
    {
        void Collect(T target);
    }
}
