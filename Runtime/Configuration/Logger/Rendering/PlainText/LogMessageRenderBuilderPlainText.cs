using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Formats;
using Openmygame.Logger.Formats.Log.PlainText;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Logger.Rendering.PlainText
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