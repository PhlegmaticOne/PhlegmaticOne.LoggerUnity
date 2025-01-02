using System;
using Openmygame.Logger.Messages;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Colors.Models
{
    [Serializable]
    public struct LogLevelColorConfigData
    {
        [SerializeField] private LogLevel _logLevel;
        [SerializeField] private Color _color;

        public LogLevelColorConfigData(LogLevel logLevel, Color color)
        {
            _logLevel = logLevel;
            _color = color;
        }

        public LogLevel LogLevel => _logLevel;
        public Color Color => _color;

        public override string ToString()
        {
            return _logLevel.ToString();
        }
    }
}