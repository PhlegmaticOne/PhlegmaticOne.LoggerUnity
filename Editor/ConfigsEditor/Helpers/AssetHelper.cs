using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Models;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Helpers
{
    internal static class AssetHelper
    {
        private const string ResourcesFolder = "Resources";
        private const string LoggerUnityFolder = "LoggerUnity";

        public static List<LoggerConfigViewModel> GetConfigs()
        {
            return ReflectionHelper.GetImplementations<LoggerConfigBase>()
                .Select(configType =>
                {
                    var configAttribute = configType.GetCustomAttribute<LoggerConfigMetadataAttribute>();
                    var config = LoadConfig(configAttribute.ConfigName);
                    return new LoggerConfigViewModel(configAttribute, configType, config);
                })
                .OrderBy(x => x.OrderInEditor)
                .ToList();
        }

        public static LoggerConfigBase CreateConfig(string configName, Type configType)
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
            
            var config = ScriptableObject.CreateInstance(configType) as LoggerConfigBase;
            config!.SetupDefaults();
            AssetDatabase.CreateAsset(config, $"Assets/{ResourcesFolder}/{LoggerUnityFolder}/{configName}.asset");
            return config;
        }

        private static LoggerConfigBase LoadConfig(string configName)
        {
            var path = Path.Combine(LoggerUnityFolder, configName);
            return Resources.Load<LoggerConfigBase>(path);
        }
    }
}