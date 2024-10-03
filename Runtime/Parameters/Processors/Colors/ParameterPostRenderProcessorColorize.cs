using System;
using System.Text;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Processors.Colors
{
    internal class ParameterPostRenderProcessorColorize : IParameterPostRenderProcessor
    {
        private const int ColorWrapLength = 23;
        
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public ParameterPostRenderProcessorColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }
        
        public void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter)
        {
            var offset = 0;
            var color = _colorsViewConfig.GetParameterColor(parameter);
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            
            Span<char> result = stackalloc char[renderedParameter.Length + ColorWrapLength];

            result.FillString("<color=#", ref offset);
            result.FillString(colorString, ref offset);
            result.FillChar('>', ref offset);
            result.FillSpan(renderedParameter, ref offset);
            result.FillString("</color>", ref offset);

            destination.Append(result);
        }
    }
}