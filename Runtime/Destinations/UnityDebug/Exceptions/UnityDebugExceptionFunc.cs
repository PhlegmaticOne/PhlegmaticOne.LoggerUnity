using System;
using Openmygame.Logger.Messages.Exceptions;

namespace Openmygame.Logger.Destinations.UnityDebug.Exceptions
{
    [Serializable]
    internal sealed class UnityDebugExceptionFunc : IUnityDebugExceptionFunc
    {
        public Exception CreateDebugException(string message, Exception innerException)
        {
            return new LogWrapException(message, innerException);
        }
    }
}