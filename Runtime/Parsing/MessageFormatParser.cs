using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormatParser : IMessageFormatParser
    {
        public MessageFormat Parse(string format, ILogMessagePartRenderer messagePartRenderer)
        {
            var parametersCount = GetParametersCount(format);

            if (parametersCount == 0)
            {
                return CreateEmpty(format, messagePartRenderer);
            }

            var i = 1;
            var parts = new MessagePart[2 * parametersCount + 1];
            ProcessFormatPrefix(format, parts, out var openBraceIndex, out var closeBraceIndex);

            while (openBraceIndex != format.Length)
            {
                var nextOpenBraceIndex = format.IndexOf('{', closeBraceIndex);
                nextOpenBraceIndex = nextOpenBraceIndex == -1 ? format.Length : nextOpenBraceIndex;
                
                var parameterPart = new MessagePart(openBraceIndex + 1, closeBraceIndex, format, true);
                var messagePart = new MessagePart(closeBraceIndex + 1, nextOpenBraceIndex, format, false);

                parts[i++] = parameterPart;
                parts[i++] = messagePart;
                
                closeBraceIndex = format.IndexOf('}', nextOpenBraceIndex);
                openBraceIndex = nextOpenBraceIndex;
            }
            
            return new MessageFormat(format, parts, messagePartRenderer);
        }

        private static void ProcessFormatPrefix(
            string format, IList<MessagePart> parts, out int openBraceIndex, out int closeBraceIndex)
        {
            openBraceIndex = format.IndexOf('{', 0);
            closeBraceIndex = format.IndexOf('}', openBraceIndex);

            if (closeBraceIndex == -1)
            {
                throw new Exception("No closing bracket");
            }

            if (openBraceIndex > 0)
            {
                parts[0] = new MessagePart(0, openBraceIndex, format, false);
            }
        }

        private static MessageFormat CreateEmpty(string format, ILogMessagePartRenderer messagePartRenderer)
        {
            var messageParts = new MessagePart[]
            {
                new(0, format.Length - 1, format, false)
            };
                
            return new MessageFormat(format, messageParts, messagePartRenderer);
        }

        private static int GetParametersCount(in ReadOnlySpan<char> format)
        {
            var count = 0;

            foreach (var letter in format)
            {
                if (letter == '{')
                {
                    count++;
                }
            }

            return count;
        }
    }
}