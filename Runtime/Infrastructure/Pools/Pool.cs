using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Infrastructure.Pools
{
    internal class Pool<T> : IPool<T> where T : class, IPoolable, new()
    {
        private readonly ConcurrentBag<T> _objects = new();
        
        public T Get()
        {
            return _objects.TryTake(out var item) ? item : new T();
        }

        public void Return(T item)
        {
            item.Release();
            _objects.Add(item);
        }
    }
}