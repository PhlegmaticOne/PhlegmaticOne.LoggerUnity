namespace OpenMyGame.LoggerUnity.Infrastructure.Pools.Base
{
    internal interface IPool { }
    internal interface IPool<T> : IPool where T : class, IPoolable
    {
        T Get();
        void Return(T item);
    }
}