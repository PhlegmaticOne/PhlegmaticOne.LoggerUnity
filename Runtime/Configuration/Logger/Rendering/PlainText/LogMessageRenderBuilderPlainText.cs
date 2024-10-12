using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Formats;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Rendering.PlainText
{
    [Serializable]
    [SerializeReferenceDropdownName("Plain text")]
    public class LogMessageRenderBuilderPlainText : LogMessageRenderBuilder
    {
        [SerializeField] private string _format = LoggerStaticData.LogFormat;
        
        public override void Build(RenderMessageOptions renderMessageOptions)
        {
            renderMessageOptions.PlainText(_format);
        }
    }
}