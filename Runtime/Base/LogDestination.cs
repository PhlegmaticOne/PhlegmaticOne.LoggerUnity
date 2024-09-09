﻿using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination
        where TConfiguration : LogConfiguration
    {
        public TConfiguration Configuration { get; set; }
        public abstract string DestinationName { get; }
        public LogConfiguration Config => Configuration;
        public bool IsEnabled { get; set; }

        public void Log(LogMessage message)
        {
            var enrichedMessage = EnrichMessage(message);
            LogMessage(enrichedMessage);
        }

        protected abstract void LogMessage(LogMessage message);

        private LogMessage EnrichMessage(LogMessage message)
        {
            foreach (var messageEnricher in Configuration.MessageEnrichers)
            {
                messageEnricher.Enrich(message);
            }

            return message;
        }
    }
}