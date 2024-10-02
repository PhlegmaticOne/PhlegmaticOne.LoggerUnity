using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig;
using UnityEditor;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow
{
    public class UnityConsoleParametersConfigEditor : ConfigEditorWindowBase<ParameterColorsViewConfig>
    {
        private const string WindowDescription = "Tags editor";

        protected override string ConfigName => "ParameterColorsViewConfig";
        protected override string CreateDescription => "Create parameter colors config";

        [MenuItem("Logger/Show parameter colors editor")]
        public static void Open()
        {
            GetWindow<UnityConsoleParametersConfigEditor>(WindowDescription);
        }
    }
}