using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Extensions;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormatParser : IMessageFormatParser
    {
        private const char OpenBrace = '{';
        private const char CloseBrace = '}';
        
        private readonly IMessageFormatFactory _messageFormatFactory;

        public MessageFormatParser(IMessageFormatFactory messageFormatFactory)
        {
            _messageFormatFactory = messageFormatFactory;
        }
        
        public IMessageFormat Parse(string format)
        {
            var parametersCount = format.CountOf(OpenBrace);

            if (parametersCount == 0)
            {
                return new MessageFormatStaticValue(format);
            }

            return ParseMessageFormat(format, parametersCount);
        }

        private IMessageFormat ParseMessageFormat(string format, int parametersCount)
        {
            var i = 1;
            var parts = new MessagePart[2 * parametersCount + 1];
            
            ProcessFormatPrefix(format, parts, out var openBraceIndex, out var closeBraceIndex);

            while (openBraceIndex != format.Length)
            {
                var nextOpenBraceIndex = format.IndexOf(OpenBrace, closeBraceIndex);
                nextOpenBraceIndex = nextOpenBraceIndex == -1 ? format.Length : nextOpenBraceIndex;
                
                var parameterPart = new MessagePart(openBraceIndex + 1, closeBraceIndex, format, true);
                var messagePart = new MessagePart(closeBraceIndex + 1, nextOpenBraceIndex, format, false);

                parts[i++] = parameterPart;
                parts[i++] = messagePart;
                
                closeBraceIndex = format.IndexOf(CloseBrace, nextOpenBraceIndex);
                openBraceIndex = nextOpenBraceIndex;
            }

            return _messageFormatFactory.CreateFormat(parts);
        }

        private static void ProcessFormatPrefix(
            string format, IList<MessagePart> parts, out int openBraceIndex, out int closeBraceIndex)
        {
            openBraceIndex = format.IndexOf(OpenBrace, 0);
            closeBraceIndex = format.IndexOf(CloseBrace, openBraceIndex);

            if (closeBraceIndex == -1)
            {
                throw new Exception("No closing bracket");
            }

            if (openBraceIndex > 0)
            {
                parts[0] = new MessagePart(0, openBraceIndex, format, false);
            }
        }
    }
}