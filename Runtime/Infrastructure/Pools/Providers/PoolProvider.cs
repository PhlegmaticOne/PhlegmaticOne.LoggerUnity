using System;
using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers
{
    internal class PoolProvider : IPoolProvider
    {
        private readonly bool _isPoolingEnabled;

        private readonly ConcurrentDictionary<Type, IPool> _pools;

        public PoolProvider(bool isPoolingEnabled)
        {
            _isPoolingEnabled = isPoolingEnabled;
            _pools = new ConcurrentDictionary<Type, IPool>();
        }

        public T Get<T>() where T : class, IPoolable, new()
        {
            return GetPool<T>().Get();
        }

        public void Return<T>(T item) where T : class, IPoolable, new()
        {
            GetPool<T>().Return(item);
        }

        private IPool<T> GetPool<T>() where T : class, IPoolable, new()
        {
            return (IPool<T>)_pools
                .GetOrAdd(typeof(T), _ => _isPoolingEnabled ? new Pool<T>() : new PoolNew<T>());
        }
    }
}