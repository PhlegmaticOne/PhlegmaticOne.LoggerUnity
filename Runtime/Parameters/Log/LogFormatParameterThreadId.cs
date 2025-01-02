using System;
using System.Threading;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterThreadId : ILogFormatParameter
    {
        public const string KeyParameter = "ThreadId";
        public string Key => KeyParameter;

        public void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message)
        {
            destination.Append(Thread.CurrentThread.ManagedThreadId);
        }
    }
}