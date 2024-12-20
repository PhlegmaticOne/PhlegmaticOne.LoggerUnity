﻿using System;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Configuration.Logger.Rendering;
using OpenMyGame.LoggerUnity.Configuration.Logger.Rendering.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations
{
    [Serializable]
    public abstract class LoggerDestinationBuilder : IDefaultSetup
    {
        [SerializeField] private LoggerPlatform _platform;
        [SerializeField] private LogLevel _minimumLogLevel = LoggerConfigurationData.MinimumLogLevel;

        [SerializeReference, SerializeReferenceDropdown] 
        private LogMessageRenderBuilder _renderBuilder = new LogMessageRenderBuilderPlainText();

        [SerializeReference, SerializeReferenceDropdown]
        private ILogFormatParameter[] _logFormatParameters;

        protected abstract LoggerPlatform Platform { get; }
        
        public bool CanBuild()
        {
            return LoggerPlatformProvider.HasPlatform(_platform);
        }
        
        public abstract void Build(LoggerBuilder loggerBuilder);

        public virtual void SetupDefaults()
        {
            _logFormatParameters = LoggerConfigurationData.LogFormatParameters
                .Select(x => x.Value)
                .ToArray();

            _platform = Platform;
        }
        
        protected void SetupConfigurationBase(LogConfiguration config)
        {
            config.MinimumLogLevel = _minimumLogLevel;
            config.Platform = _platform;
            _renderBuilder.Build(config.RenderAs);
            AddLogFormatParameters(config);
        }

        private void AddLogFormatParameters(LogConfiguration config)
        {
            if (_logFormatParameters == null || _logFormatParameters.Length == 0)
            {
                return;
            }
            
            foreach (var logFormatParameter in _logFormatParameters)
            {
                config.AddLogFormatParameter(logFormatParameter);
            }
        }
    }
}