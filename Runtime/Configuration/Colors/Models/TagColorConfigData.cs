using System;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Colors.Models
{
    [Serializable]
    public struct TagColorConfigData
    {
        [SerializeField] private string _tag;
        [SerializeField] private Color _color;

        public TagColorConfigData(string tag, Color color)
        {
            _tag = tag;
            _color = color;
        }

        public string Tag => _tag;
        public Color Color => _color;

        public bool ContainsData()
        {
            return !string.IsNullOrEmpty(_tag);
        }

        public override string ToString()
        {
            return _tag;
        }
    }
}