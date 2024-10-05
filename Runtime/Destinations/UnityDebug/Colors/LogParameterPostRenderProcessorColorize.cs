using System;
using System.Text;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    public class LogParameterPostRenderProcessorColorize : ILogParameterPostRenderProcessor
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public LogParameterPostRenderProcessorColorize(IParameterColorsViewConfig colorsViewConfig)
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
            
            var color = _colorsViewConfig.GetLogParameterColor(value.ToString());
            UnityDebugColorWrapper.Wrap(destination, in renderedValue, color);
        }

        private static bool ValueIsNewLine(in ReadOnlySpan<char> messagePart)
        {
            return messagePart.Equals(LoggerStaticData.NewLineKey, StringComparison.OrdinalIgnoreCase);
        }
        
        private static bool ValueIsMessage(in ReadOnlySpan<char> messagePart)
        {
            return messagePart.Equals(LoggerStaticData.MessageKey, StringComparison.OrdinalIgnoreCase);
        }
    }
}