using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Formats;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Rendering.PlainText
{
    [Serializable]
    [SerializeReferenceDropdownName("Plain text")]
    public class LogMessageRenderBuilderPlainText : LogMessageRenderBuilder
    {
        [SerializeField] private string _format = LoggerConfigurationData.LogFormat;
        
        public override void Build(RenderMessageOptions renderMessageOptions)
        {
            renderMessageOptions.PlainText(_format);
        }
    }
}