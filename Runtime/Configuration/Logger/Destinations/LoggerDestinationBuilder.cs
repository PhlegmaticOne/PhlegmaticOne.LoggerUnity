using System;
using System.Linq;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
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
        [SerializeField] private bool _isEnabled = LoggerStaticData.IsEnabled;
        [SerializeField] private LoggerPlatform _platform;
        [SerializeField] private LogLevel _minimumLogLevel = LoggerStaticData.MinimumLogLevel;

        [SerializeReference, SerializeReferenceDropdown] 
        private LogMessageRenderBuilder _renderBuilder = new LogMessageRenderBuilderPlainText();

        [SerializeReference, SerializeReferenceDropdown]
        private ILogFormatParameter[] _logFormatParameters;

        protected abstract LoggerPlatform Platform { get; }
        
        public bool CanBuild()
        {
            var currentPlatform = LoggerPlatformProvider.GetPlatform();
            return _platform.HasFlag(currentPlatform);
        }
        
        public abstract void Build(LoggerBuilder loggerBuilder);

        public virtual void SetupDefaults()
        {
            _logFormatParameters = LoggerStaticData.LogFormatParameters
                .Select(x => x.Value)
                .ToArray();

            _platform = Platform;
        }
        
        protected void SetupConfigurationBase(LogConfiguration config)
        {
            config.IsEnabled = _isEnabled;
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