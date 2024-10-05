﻿using System;
using OpenMyGame.LoggerUnity.Messages;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig
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
    }
}