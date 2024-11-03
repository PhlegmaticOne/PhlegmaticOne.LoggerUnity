using System;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    internal class LogParameterProcessorColorize : ILogParameterProcessor
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public LogParameterProcessorColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }

        public void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue)
        {
            var value = messagePart.GetValue();
            
            if (CannotProcess(messagePart, value))
            {
                return;
            }
            
            var color = _colorsViewConfig.GetLogParameterColor(value.ToString(), parameterValue);
            destination.AppendColorPrefix(color);
        }

        public void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart)
        {
            if (CannotProcess(messagePart, messagePart.GetValue()))
            {
                return;
            }
            
            destination.AppendColorPostfix();
        }

        private static bool CannotProcess(in MessagePart messagePart, in ReadOnlySpan<char> value)
        {
            return !messagePart.IsParameter || ValueIsNewLine(value);
        }

        private static bool ValueIsNewLine(in ReadOnlySpan<char> messagePart)
        {
            return messagePart.Equals(LogFormatParameterNewLine.KeyParameter, StringComparison.OrdinalIgnoreCase);
        }
    }
}