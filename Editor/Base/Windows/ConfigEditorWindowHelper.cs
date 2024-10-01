using System.IO;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor
{
    internal static class ConfigEditorWindowHelper
    {
        private const string ResourcesFolder = "Resources";
        private const string LoggerUnityFolder = "LoggerUnity";

        public static T LoadConfig<T>(string configName) where T : ScriptableObject
        {
            var path = Path.Combine(LoggerUnityFolder, configName);
            return Resources.Load<T>(path);
        }
        
        public static T CreateConfig<T>(string configName) where T : ScriptableObject
        {
            var path = Path.Combine(Application.dataPath, ResourcesFolder);

            if (!Directory.Exists(path))
            {
                AssetDatabase.CreateFolder("Assets", ResourcesFolder);
            }

            path = Path.Combine(path, LoggerUnityFolder);
                
            if (!Directory.Exists(path))
            {
                AssetDatabase.CreateFolder($"Assets/{ResourcesFolder}", LoggerUnityFolder);
            }
                
            var config = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(config, $"Assets/{ResourcesFolder}/{LoggerUnityFolder}/{configName}.asset");
            return config;
        }
    }
}