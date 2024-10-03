using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig
{
    public class ParameterColorsViewConfigRandom : IParameterColorsViewConfig
    {
        public Color GetParameterColor(object parameter)
        {
            return new Color(Random.value, Random.value, Random.value);
        }
    }
}