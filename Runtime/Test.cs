using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Destinations.UnityDebug;
using OpenMyGame.LoggerUnity.Runtime.Destinations.UnityDebug.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            // 1. Testing
            // Cache formats
            // 2. Sample
            // 3. Native logs

            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag:c}#")
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Stacktrace}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
            
            Log.WithTag("Tag").Debug("Message {Parameter}", TimeSpan.Zero);
            Log.WithTag("Test").Debug("Message {Parameter}", TimeSpan.Zero);
        }
    }
}