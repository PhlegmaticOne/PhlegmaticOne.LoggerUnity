using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base
{
    public interface IParameterColorsViewConfig
    {
        Color GetTagColor(string tag);
        Color GetMessageParameterColor(object parameter);
        Color GetLogParameterColor(string parameterKey, in ReadOnlySpan<char> renderedValue);
    }
}