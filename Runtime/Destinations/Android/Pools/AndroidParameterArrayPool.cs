using System;
using System.Collections.Concurrent;

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    internal class AndroidParameterArrayPool
    {
        private readonly ConcurrentBag<object[]> _objects = new();
        
        public object[] Get()
        {
            return _objects.TryTake(out var item) ? item : new object[3];
        }
        
        public void Return(object[] item)
        {
            Array.Clear(item, 0, item.Length);
            _objects.Add(item);
        }
    }
}