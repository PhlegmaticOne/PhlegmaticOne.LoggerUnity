using System;
using Openmygame.Logger.Infrastructure.StringBuilders;

namespace Openmygame.Logger.Parameters.Message.Base
{
    [Serializable]
    public abstract class MessageFormatParameter<T> : IMessageFormatParameter
    {
        public Type PropertyType => typeof(T);
        
        public void Render(ref ValueStringBuilder destination, object parameter, ReadOnlySpan<char> format)
        {
            if (parameter is T generic)
            {
                Render(ref destination, generic, format);
            }
        }

        protected abstract void Render(ref ValueStringBuilder destination, T parameter, in ReadOnlySpan<char> format);
    }
}