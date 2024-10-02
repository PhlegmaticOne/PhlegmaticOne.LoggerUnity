using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig
{
    [Serializable]
    public struct KeyColorConfigData
    {
        [SerializeField] private string _key;
        [SerializeField] private Color _color;

        public string Key => _key;
        public Color Color => _color;

        public bool ContainsData()
        {
            return !string.IsNullOrEmpty(_key);
        }
    }
}