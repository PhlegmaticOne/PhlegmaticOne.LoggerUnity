using System;

namespace Openmygame.Logger.Destinations.UnityDebug.Exceptions
{
    public interface IUnityDebugExceptionFunc
    {
        Exception CreateDebugException(string message, Exception innerException);
    }
}