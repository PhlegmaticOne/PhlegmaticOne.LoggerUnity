using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Colors.Models
{
    [Serializable]
    public struct KeyColorConfigData
    {
        [SerializeField] private string _key;
        [SerializeField] private Color _color;

        public KeyColorConfigData(string key, Color color)
        {
            _key = key;
            _color = color;
        }

        public string Key => _key;
        public Color Color => _color;

        public bool ContainsData()
        {
            return !string.IsNullOrEmpty(_key);
        }
    }
}