using System;
using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Log;
using Openmygame.Logger.Parameters.Log.Processors;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Destinations.UnityDebug.Colors
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