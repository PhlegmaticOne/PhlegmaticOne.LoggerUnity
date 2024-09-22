﻿using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Destinations.UnityDebug.Extensions
{
    public static class LogLevelToLogTypeConverter
    {
        public static LogType Convert(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Debug => LogType.Log,
                LogLevel.Warning => LogType.Warning,
                LogLevel.Error => LogType.Error,
                LogLevel.Fatal => LogType.Exception,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
            };
        }
    }
}