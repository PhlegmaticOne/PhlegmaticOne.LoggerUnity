using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Colors.Models
{
    [Serializable]
    public struct LogParameterColorConfigData
    {
        [SerializeReference, SerializeReferenceDropdown] private ILogFormatParameter _logParameter;
        [SerializeField] private Color _color;

        public LogParameterColorConfigData(ILogFormatParameter logParameter, Color color)
        {
            _logParameter = logParameter;
            _color = color;
        }

        public Color Color => _color;

        public bool ParameterEquals(in ReadOnlySpan<char> parameterKey)
        {
            return parameterKey.Equals(_logParameter.Key, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return _logParameter.Key;
        }
    }
}