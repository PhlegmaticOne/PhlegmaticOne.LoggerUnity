using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Infrastructure.Pools
{
    internal class PoolNew<T> : IPool<T> where T : class, IPoolable, new()
    {
        public T Get() => new();

        public void Return(T item) { }
    }
}