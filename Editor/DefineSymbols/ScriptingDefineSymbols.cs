using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;

namespace OpenMyGame.LoggerUnity.Editor.DefineSymbols
{
    internal static class ScriptingDefineSymbols
    {
        public static void AddDefineToTarget(NamedBuildTarget target, string define)
        {
            AddDefinesToTarget(target, new[] { define });
        }

        public static void AddDefinesToTarget(NamedBuildTarget target, string[] defines)
        {
            PlayerSettings.GetScriptingDefineSymbols(target, out var currentDefines);
            PlayerSettings.SetScriptingDefineSymbols(target, AddDefines(currentDefines, defines));
        }

        public static void RemoveDefineFromTarget(NamedBuildTarget target, string define)
        {
            RemoveDefinesFromTarget(target, new[] { define });
        }

        public static void RemoveDefinesFromTarget(NamedBuildTarget target, string[] define)
        {
            PlayerSettings.GetScriptingDefineSymbols(target, out var currentDefines);
            PlayerSettings.SetScriptingDefineSymbols(target, RemoveDefines(currentDefines, define));
        }

        public static bool TargetHasDefine(NamedBuildTarget target, string define)
        {
            return TargetHasDefines(target, new[] { define });
        }
        
        public static bool TargetHasDefines(NamedBuildTarget target, string[] defines)
        {
            PlayerSettings.GetScriptingDefineSymbols(target, out var currentDefines);
            var currentDefinesSet = new HashSet<string>(currentDefines);
            return defines.All(x => currentDefinesSet.Contains(x));
        }

        private static string[] RemoveDefines(string[] currentDefines, string[] defines)
        {
            var definesSet = new HashSet<string>(defines);
            return currentDefines.Where(currentDefine => !definesSet.Contains(currentDefine)).ToArray();
        }

        private static string[] AddDefines(string[] currentDefines, string[] defines)
        {
            var resultDefines = new string[currentDefines.Length + defines.Length];
            currentDefines.CopyTo(resultDefines, 0);
            defines.CopyTo(resultDefines, currentDefines.Length);
            return resultDefines;
        }

    }
}