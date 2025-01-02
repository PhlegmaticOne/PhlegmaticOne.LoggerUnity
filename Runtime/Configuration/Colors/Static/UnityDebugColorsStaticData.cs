using System.Collections.Generic;
using Openmygame.Logger.Parameters.Log;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parameters.Message;
using Openmygame.Logger.Parameters.Message.Base;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Colors.Static
{
    internal static class UnityDebugColorsStaticData
    {
        private static readonly Color DefaultTimeColor = new(0.1254902f, 0.6470588f, 0.2862745f);
        
        public static Dictionary<ILogFormatParameter, Color> LogParameterColorsMap => new()
        {
            { new LogFormatParameterException(), new Color(1f, 0.3254902f, 0.2901961f) },
            { new LogFormatParameterThreadId(), new Color(0f, 1f, 1f) },
            { new LogFormatParameterTime(), DefaultTimeColor },
            { new LogFormatParameterTimeUtc(), DefaultTimeColor },
            { new LogFormatParameterUnityTime(), DefaultTimeColor},
            { new LogFormatParameterMessageId(), new Color(0.9882353f, 0.9254902f, 0.3215686f)}
        };

        public static Dictionary<IMessageFormatParameter, Color> MessageParameterColorsMap => new()
        {
            { new MessageFormatParameterString(), new Color(0.9607844f, 0.8745099f, 0.7098039f) },
            { new MessageFormatParameterDateTime(), DefaultTimeColor },
            { new MessageFormatParameterTimeSpan(), DefaultTimeColor },
            { new MessageFormatParameterGuid(), new Color(0.03137255f, 0.5764706f, 0.03137255f) },
            { new MessageFormatParameterExceptionPlaceholder(), new Color(0.7894118f, 0.09019608f, 0.07058824f) }
        };

        public static Dictionary<string, Color> LogLevelColorsMap => new()
        {
            { "Debug", new Color(0.7686275f, 0.7686275f, 0.7686275f) },
            { "Warning", new Color(0.9058824f, 0.6980392f, 0.07058824f) },
            { "Error", new Color(1f, 0.3254902f, 0.2901961f) },
            { "Fatal", new Color(1f, 0.3254902f, 0.2901961f) },
        };
    }
}