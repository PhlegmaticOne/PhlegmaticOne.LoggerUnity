using System;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    internal class LogParameterPostRendererColorize : ILogParameterPostRenderer
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public LogParameterPostRendererColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }

        public void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue)
        {
            var value = messagePart.GetValue();
            
            if (CanProcess(messagePart, value))
            {
                return;
            }
            
            var color = _colorsViewConfig.GetLogParameterColor(value.ToString(), parameterValue);
            destination.AppendColorPrefix(color);
        }

        public void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart)
        {
            if (CanProcess(messagePart, messagePart.GetValue()))
            {
                return;
            }
            
            destination.AppendColorPostfix();
        }

        private static bool CanProcess(in MessagePart messagePart, in ReadOnlySpan<char> value)
        {
            return !messagePart.IsParameter || ValueIsMessage(value) || ValueIsNewLine(value);
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