using UnityEngine;

namespace Openmygame.Logger.Configuration.Colors.Base
{
    public interface IParameterColorsViewConfig
    {
        Color GetSubsystemColor();
        Color GetTagColor(string tag);
        Color GetMessageParameterColor(object parameter);
        Color GetLogParameterColor(string key, object parameterValue);
    }
}