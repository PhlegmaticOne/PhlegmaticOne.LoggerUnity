using System.Text;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Infrastructure.Pools.PoolableTypes
{
    public class StringBuilderPoolable : IPoolable
    {
        public StringBuilderPoolable()
        {
            Value = new StringBuilder();
        }

        public StringBuilder Value { get; }
        
        public string ToStringResult()
        {
            return Value.ToString();
        }

        public void Clear()
        {
            Value.Clear();
        }
        
        public void Release()
        {
            Clear();
        }
    }
}