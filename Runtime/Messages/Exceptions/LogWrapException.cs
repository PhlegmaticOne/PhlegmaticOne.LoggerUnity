using System;
using System.Text;

namespace Openmygame.Logger.Messages.Exceptions
{
    internal sealed class LogWrapException : Exception
    {
        private readonly Exception _innerException;

        public LogWrapException(string message, Exception innerException)
        {
            Message = BuildMessage(message, innerException);
        }

        public override string Message { get; }

        public override string StackTrace => _innerException is not null ? _innerException.StackTrace : base.StackTrace;

        private static string BuildMessage(string message, Exception innerException)
        {
            var sb = new StringBuilder(message);

            if (innerException is not null)
            {
                sb.AppendLine();
                sb.Append(innerException.GetType().Name);
                sb.Append(':');
                sb.Append(innerException.Message);
            }

            return sb.ToString();
        }
    }
}