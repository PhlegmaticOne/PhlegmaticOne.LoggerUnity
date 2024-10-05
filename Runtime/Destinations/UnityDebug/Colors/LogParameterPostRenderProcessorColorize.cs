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
            if (ParameterIsMessage(messagePart))
            {
                destination.Append(renderedValue);
                return;
            }
            
            var color = _colorsViewConfig.GetLogParameterColor(messagePart.GetValueAsString());
            UnityDebugColorWrapper.Wrap(destination, in renderedValue, color);
        }

        private static bool ParameterIsMessage(in MessagePart messagePart)
        {
            return messagePart
                .GetValue()
                .Equals(LoggerStaticData.MessageKey, StringComparison.OrdinalIgnoreCase);
        }
    }
}