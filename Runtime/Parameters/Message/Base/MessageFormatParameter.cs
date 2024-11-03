using System;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Base
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