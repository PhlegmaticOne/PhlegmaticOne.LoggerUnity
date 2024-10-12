using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Helpers;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Models;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Views;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor
{
    public class LoggerConfigsEditorWindow : EditorWindow
    {
        private List<LoggerConfigViewModel> _configs;
        
        private ConfigNameView _configNameView;
        private ConfigSeparatorLineView _configSeparatorLineView;
        
        private Vector2 _scrollPosition;

        [MenuItem("Logger/Show configs editor")]
        public static void Open()
        {
            var window = GetWindow<LoggerConfigsEditorWindow>("Logger configs editor");
            window.minSize = new Vector2(400, 400);
            window.Show();
        }
        
        private void CreateGUI()
        {
            _configs = AssetHelper.GetConfigs();
            _configNameView = new ConfigNameView();
            _configSeparatorLineView = new ConfigSeparatorLineView();
        }

        private void OnGUI()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            EditorGUILayout.Separator();
            DrawConfigEditors();
            EditorGUILayout.EndScrollView();
        }

        private void DrawConfigEditors()
        {
            foreach (var viewModel in _configs)
            {
                if (viewModel.IsCreated)
                {
                    _configNameView.Draw(viewModel.Name);
                    EditorGUILayout.Separator();
                    viewModel.HandleRedraw();
                    EditorGUILayout.Separator();
                    _configSeparatorLineView.Draw();
                }
                else
                {
                    TryCreateConfig(viewModel);
                    EditorGUILayout.Separator();
                }
            }
        }
        
        private static void TryCreateConfig(LoggerConfigViewModel viewModel)
        {
            if (GUILayout.Button(viewModel.CreateDescription))
            {
                var config = AssetHelper.CreateConfig(viewModel.Name, viewModel.ConfigType);
                viewModel.SetConfig(config);
            }
        }
    }
}