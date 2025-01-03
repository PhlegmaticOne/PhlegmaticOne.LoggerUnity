using System;
using System.Runtime.InteropServices;
using Openmygame.Logger.Base;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;

namespace Openmygame.Logger
{
    internal sealed class LogTag : ILogger
    {
        private readonly ILogger _logger;
        private readonly Tag _tag;

        internal LogTag(Tag tag, ILogger logger)
        {
            _tag = tag;
            _logger = logger;
            IsEnabled = true;
        }

        public bool IsEnabled { get; set; }

        public void LogMessage(LogMessage message, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            message.SetFormat(_tag.AddToFormat(message.Format));

            var parametersSpan = MemoryMarshal.CreateSpan(ref parameters[0], parameters.Length + 1);
            parameters.CopyTo(parametersSpan[1..]);
            parametersSpan[0] = _tag;
            
            _logger.LogMessage(message, parametersSpan);
        }
    }
}