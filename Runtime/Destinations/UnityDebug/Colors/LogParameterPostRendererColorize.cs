using System;
using System.Text;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    internal class LogParameterPostRendererColorize : ILogParameterPostRenderer
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public LogParameterPostRendererColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }
        
        public void Process(StringBuilder destination, in MessagePart messagePart, in ReadOnlySpan<char> renderedValue)
        {
            var value = messagePart.GetValue();
            
            if (renderedValue.IsEmpty || ValueIsMessage(value) || ValueIsNewLine(value))
            {
                destination.Append(renderedValue);
                return;
            }
            
            var color = _colorsViewConfig.GetLogParameterColor(value.ToString(), renderedValue);
            UnityDebugStringColorizer.ColorizeNonHeapAlloc(destination, in renderedValue, color);
        }

        private static bool ValueIsNewLine(in ReadOnlySpan<char> messagePart)
        {
            return messagePart.Equals(LogFormatParameterNewLine.KeyParameter, StringComparison.OrdinalIgnoreCase);
        }
        
        private static bool ValueIsMessage(in ReadOnlySpan<char> messagePart)
        {
            return messagePart.Equals(LogFormatParameterMessage.KeyParameter, StringComparison.OrdinalIgnoreCase);
        }
    }
}