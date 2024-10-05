using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Static
{
    internal static class UnityDebugColorsStaticData
    {
        private static readonly Color DefaultTimeColor = new(0.1254902f, 0.6470588f, 0.2862745f);
        
        public static Dictionary<string, Color> LogParameterColorsMap => new()
        {
            { LogFormatParameterException.KeyParameter, new Color(1f, 0.3254902f, 0.2901961f) },
            { LogFormatParameterThreadId.KeyParameter, new Color(0f, 1f, 1f) },
            { LogFormatParameterTime.KeyParameter, DefaultTimeColor },
            { LogFormatParameterTimeUtc.KeyParameter, DefaultTimeColor },
            { LogFormatParameterUnityTime.KeyParameter, DefaultTimeColor}
        };

        public static Dictionary<string, Color> MessageParameterColorsMap => new()
        {
            { nameof(String), new Color(0.9607844f, 0.8745099f, 0.7098039f) },
            { nameof(DateTime), DefaultTimeColor },
            { nameof(TimeSpan), DefaultTimeColor },
            { nameof(Guid), new Color(0.03137255f, 0.5764706f, 0.03137255f) },
            { nameof(LogExceptionPlaceholder), new Color(0.7894118f, 0.09019608f, 0.07058824f) }
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