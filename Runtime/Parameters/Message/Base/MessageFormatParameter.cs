using System;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Base
{
    public abstract class MessageFormatParameter<T> : IMessageFormatParameter
    {
        public Type PropertyType => typeof(T);
        
        public ReadOnlySpan<char> Render(object parameter, ReadOnlySpan<char> format)
        {
            return parameter is T generic ? Render(generic, format) : ReadOnlySpan<char>.Empty;
        }

        protected abstract ReadOnlySpan<char> Render(T parameter, in ReadOnlySpan<char> format);
    }
}