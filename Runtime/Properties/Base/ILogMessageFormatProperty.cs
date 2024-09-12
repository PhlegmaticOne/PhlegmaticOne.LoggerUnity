using System;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Base
{
    public interface ILogMessageFormatProperty
    {
        Type PropertyType { get; }
        ReadOnlySpan<char> Render(object parameter, in ReadOnlySpan<char> format);
    }

    public abstract class LogMessageFormatProperty<T> : ILogMessageFormatProperty
    {
        public Type PropertyType => typeof(T);
        
        public ReadOnlySpan<char> Render(object parameter, in ReadOnlySpan<char> format)
        {
            return parameter is T generic ? Render(generic, format) : ReadOnlySpan<char>.Empty;
        }

        protected abstract ReadOnlySpan<char> Render(T parameter, in ReadOnlySpan<char> format);
    }
}