using System;
using System.Text;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    internal class MessageParameterPostRendererColorize : IMessageParameterPostRenderer
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public MessageParameterPostRendererColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }
        
        public void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter)
        {
            if (parameter is LogTag logTag)
            {
                var color = _colorsViewConfig.GetTagColor(logTag.Value);
                
                UnityDebugStringColorizer.ColorizeNonHeapAlloc(
                    destination, in renderedParameter, color,
                    LogTag.Format.Prefix, LogTag.Format.Postfix);
            }
            else
            {
                var color = _colorsViewConfig.GetMessageParameterColor(parameter);
                UnityDebugStringColorizer.ColorizeNonHeapAlloc(destination, in renderedParameter, color);
            }
        }
    }
}