﻿using System;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination
        where TConfiguration : LogConfiguration
    {
        private TConfiguration _configuration;
        private IMessageFormat _logFormat;

        internal TConfiguration Configuration
        {
            get => _configuration;
            set
            {
                _configuration = value;
                IsEnabled = _configuration.IsEnabled;
            }
        }

        public abstract string DestinationName { get; }
        public LogConfiguration Config => Configuration;
        public bool IsEnabled { get; set; }

        public void Initialize()
        {
            _logFormat = Configuration.CreateMessageFormat();
            OnInitializing();
        }

        public virtual void LogMessage(LogMessage message, Span<object> parameters)
        {
            var renderedMessage = _logFormat.Render(message, parameters);
            LogRenderedMessage(message, renderedMessage, parameters);
        }

        public virtual void Release() { }

        protected abstract void LogRenderedMessage(LogMessage logMessage, string renderedMessage, Span<object> parameters);
        protected virtual void OnInitializing() { }

        public override string ToString() => DestinationName;
    }
}