using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig
{
    public class ParameterColorsViewConfigStaticWhite : IParameterColorsViewConfig
    {
        public Color GetTagColor(string tag) => Color.white;

        public Color GetMessageParameterColor(object parameter) => Color.white;

        public Color GetLogParameterColor(string parameterKey) => Color.white;
    }
}