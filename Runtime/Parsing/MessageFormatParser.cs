using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Exceptions;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing
{
    /// <summary>
    /// Класс для парсинга форматов сообщений
    /// </summary>
    internal class MessageFormatParser : IMessageFormatParser
    {
        private const char OpenBrace = '{';
        private const char CloseBrace = '}';
        
        /// <summary>
        /// Парсит строку с форматом в формат с параметрами и частями сообщений
        /// </summary>
        /// <param name="format">Формат в виде строки</param>
        /// <example>[{ThreadId}] {Message}{NewLine}{Exception}</example>
        /// <exception cref="MessageFormatParseException">Формат пустой; в формате разное количество '{' и '}'</exception>
        public MessagePart[] Parse(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new MessageFormatParseException("Input format cannot be empty string");
            }
            
            var (countOpenBraces, countCloseBraces) = format.CountBraces();

            if (countOpenBraces == 0 && countCloseBraces == 0)
            {
                return new[] { MessagePart.Message(format) };
            }

            if (countOpenBraces != countCloseBraces)
            {
                throw new MessageFormatParseException("Format must have similar count of open and close braces");
            }

            return ParseMessageFormat(format, countOpenBraces);
        }

        private static MessagePart[] ParseMessageFormat(string format, int parametersCount)
        {
            var i = 1;
            var partsCount = 2 * parametersCount + 1;
            var parts = new MessagePart[partsCount];
            
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
                
                if (closeBraceIndex == -1 && i != partsCount)
                {
                    throw new MessageFormatParseException($"Input format has no closing brace for one of open braces: {format}");
                }
                
                openBraceIndex = nextOpenBraceIndex;
            }

            return parts;
        }

        private static void ProcessFormatPrefix(
            string format, IList<MessagePart> parts, out int openBraceIndex, out int closeBraceIndex)
        {
            openBraceIndex = format.IndexOf(OpenBrace, 0);
            closeBraceIndex = format.IndexOf(CloseBrace, openBraceIndex);

            if (closeBraceIndex == -1)
            {
                throw new MessageFormatParseException($"Input format has no closing brace for one of open braces: {format}");
            }

            if (openBraceIndex > 0)
            {
                parts[0] = new MessagePart(0, openBraceIndex, format, false);
            }
        }
    }
}