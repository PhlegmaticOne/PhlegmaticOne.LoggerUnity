using Openmygame.Logger.Configuration;
using UnityEditor;
using UnityEditor.Build;

namespace Openmygame.Logger.Editor.DefineSymbols
{
    internal static class LoggerActivityEditorUtility
    {
        private const string EnableLoggerDefineName = LoggerConfigurationData.ConditionalName;
        private const string LoggerEnableItemName = "Logger/Enable ";
        private const string LoggerDisableItemName = "Logger/Disable ";
        
        [MenuItem(LoggerEnableItemName, priority = 0)]
        public static void EnableLogging()
        {
            ScriptingDefineSymbols.AddDefineToTarget(NamedBuildTarget.Android, EnableLoggerDefineName);
            ScriptingDefineSymbols.AddDefineToTarget(NamedBuildTarget.iOS, EnableLoggerDefineName);
        }
        
        [MenuItem(LoggerEnableItemName, isValidateFunction: true, priority = 0)]
        public static bool EnableLoggingValidation()
        {
            return !ScriptingDefineSymbols.TargetHasDefine(NamedBuildTarget.Android, EnableLoggerDefineName) &&
                   !ScriptingDefineSymbols.TargetHasDefine(NamedBuildTarget.iOS, EnableLoggerDefineName);
        }
        
        [MenuItem(LoggerDisableItemName, priority = 0)]
        public static void DisableLogging()
        {
            ScriptingDefineSymbols.RemoveDefineFromTarget(NamedBuildTarget.Android, EnableLoggerDefineName);
            ScriptingDefineSymbols.RemoveDefineFromTarget(NamedBuildTarget.iOS, EnableLoggerDefineName);
        }
        
        [MenuItem(LoggerDisableItemName, isValidateFunction: true, priority = 0)]
        public static bool DisableLoggingValidation()
        {
            return ScriptingDefineSymbols.TargetHasDefine(NamedBuildTarget.Android, EnableLoggerDefineName) ||
                   ScriptingDefineSymbols.TargetHasDefine(NamedBuildTarget.iOS, EnableLoggerDefineName);
        }
    }
}