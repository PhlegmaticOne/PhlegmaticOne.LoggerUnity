using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig
{
    [Serializable]
    public struct TagColorConfigData
    {
        [SerializeField] private string _tag;
        [SerializeField] private Color _color;

        public string Tag => _tag;
        public Color Color => _color;
    }
}