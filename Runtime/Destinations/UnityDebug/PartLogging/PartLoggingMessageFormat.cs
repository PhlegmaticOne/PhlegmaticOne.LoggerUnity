using System;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parsing;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Destinations.UnityDebug.PartLogging
{
    internal class PartLoggingMessageFormat
    {
        private readonly MessagePart[] _messageParts;
        
        public PartLoggingMessageFormat(string format)
        {
            var parser = new MessageFormatParser();
            _messageParts = parser.Parse(format);
        }
        
        public ValueStringBuilder CreatePart(ref PartLoggingParameters parameters)
        {
            var builder = new ValueStringBuilder();

            foreach (var messagePart in _messageParts)
            {
                var value = messagePart.GetValue();
                
                if (!messagePart.IsParameter)
                {
                    builder.Append(value);
                    continue;
                }

                if (value.SequenceEqual(PartLoggingParameters.MessageIdKey))
                {
                    builder.Append(parameters.MessageId);
                    continue;
                }
                
                if (value.SequenceEqual(PartLoggingParameters.MessagePartKey))
                {
                    builder.Append(parameters.MessagePart);
                    continue;
                }
                
                if (value.SequenceEqual(PartLoggingParameters.PartIndexKey))
                {
                    builder.Append(parameters.PartIndex);
                    continue;
                }
                
                if (value.SequenceEqual(PartLoggingParameters.PartsCountKey))
                {
                    builder.Append(parameters.PartsCount);
                }
            }
            
            return builder;
        }
    }
}