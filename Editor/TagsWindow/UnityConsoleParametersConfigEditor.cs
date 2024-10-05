using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using UnityEditor;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow
{
    public class UnityConsoleParametersConfigEditor : ConfigEditorWindowBase<ParameterColorsViewConfig>
    {
        private const string WindowDescription = "Parameter colors editor";

        protected override string ConfigName => "ParameterColorsViewConfig";
        protected override string CreateDescription => "Create parameter colors config";
        
        protected override void OnConfigCreating(ParameterColorsViewConfig config)
        {
            config.SetupDefaults();
        }

        [MenuItem("Logger/Show parameter colors editor")]
        public static void Open()
        {
            GetWindow<UnityConsoleParametersConfigEditor>(WindowDescription);
        }
    }
}