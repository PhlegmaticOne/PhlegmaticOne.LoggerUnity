using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class ExceptionExtensions
    {
        public static string ToStringNoStacktrace(this Exception exception)
        {
            var result = new StringBuilder();
            var exceptionClassName = exception.GetType().Name;
            var message = exception.Message;

            result.Append(exceptionClassName);

            if (message is { Length: > 0 })
            {
                result.Append(": ");
                result.Append(message);
            }
            
            if (exception.InnerException != null)
            {
                result.Append(" ---> ");
                result.Append(exception.InnerException);
            }

            return result.ToString();
        }
    }
}