using System;
using System.Text;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
{
    internal class MessageParameterPostRenderProcessorColorize : IMessageParameterPostRenderProcessor
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public MessageParameterPostRenderProcessorColorize(IParameterColorsViewConfig colorsViewConfig)
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
            var color = _colorsViewConfig.GetTagColor(logTag.Tag);
            logTag.SetColor(color);
            return color;
        }
    }
}