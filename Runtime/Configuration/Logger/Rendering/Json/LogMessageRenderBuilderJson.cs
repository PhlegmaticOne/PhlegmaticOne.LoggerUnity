using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Formats;
using OpenMyGame.LoggerUnity.Formats.Log.Json;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Rendering.Json
{
    [Serializable]
    [SerializeReferenceDropdownName("JSON")]
    public class LogMessageRenderBuilderJson : LogMessageRenderBuilder
    {
        [SerializeReference, SerializeReferenceDropdown]
        private ILogFormatParameter[] _includeLogParameters;
        
        public override void Build(RenderMessageOptions renderMessageOptions)
        {
            renderMessageOptions.Json(IncludeLogParameters);
        }

        public override void SetupDefaults()
        {
            _includeLogParameters = new ILogFormatParameter[]
            {
                new LogFormatParameterMessage(),
                new LogFormatParameterException()
            };
        }

        private void IncludeLogParameters(JsonIncludeParametersBuilder parametersBuilder)
        {
            if (_includeLogParameters == null || _includeLogParameters.Length == 0)
            {
                return;
            }

            foreach (var includeLogParameter in _includeLogParameters)
            {
                parametersBuilder.Parameter(includeLogParameter.Key);
            }
        }
    }
}