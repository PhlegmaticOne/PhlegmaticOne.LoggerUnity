using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Colors.Base
{
    public interface IParameterColorsViewConfig
    {
        Color GetTagColor(string tag);
        Color GetMessageParameterColor(object parameter);
        Color GetLogParameterColor(in ReadOnlySpan<char> parameterKey, in ReadOnlySpan<char> renderedValue);
    }
}