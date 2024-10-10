using System;
using System.Text;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
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
            var color = parameter is LogTag logTag 
                ? GetTagColor(logTag) 
                : _colorsViewConfig.GetMessageParameterColor(parameter);
            
            UnityDebugStringColorizer.ColorizeNonHeapAlloc(destination, in renderedParameter, color);
        }

        private Color GetTagColor(LogTag logTag)
        {
            var color = _colorsViewConfig.GetTagColor(logTag.Value);
            logTag.SetColor(color);
            return color;
        }
    }
}