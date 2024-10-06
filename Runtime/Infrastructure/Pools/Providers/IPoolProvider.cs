using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers
{
    public interface IPoolProvider
    {
        T Get<T>() where T : class, IPoolable, new();
        void Return<T>(T item) where T : class, IPoolable, new();
    }
}