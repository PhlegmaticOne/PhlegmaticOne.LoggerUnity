using System;
using System.Linq;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Base;
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
        [SerializeField] private LogLevel _minimumLogLevel = LoggerStaticData.MinimumLogLevel;

        [SerializeReference, SerializeReferenceDropdown] 
        private LogMessageRenderBuilder _renderBuilder = new LogMessageRenderBuilderPlainText();

        [SerializeReference, SerializeReferenceDropdown]
        private ILogFormatParameter[] _logFormatParameters;
        
        public abstract void Build(LoggerBuilder loggerBuilder);

        public virtual void SetupDefaults()
        {
            _logFormatParameters = LoggerStaticData.LogFormatParameters
                .Select(x => x.Value)
                .ToArray();
        }

        protected void SetupConfigurationBase(LogConfiguration config)
        {
            config.IsEnabled = _isEnabled;
            config.MinimumLogLevel = _minimumLogLevel;
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