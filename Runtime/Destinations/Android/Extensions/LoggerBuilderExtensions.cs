﻿using System;

namespace OpenMyGame.LoggerUnity.Destinations.Android.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToAndroidLog(
            this LoggerBuilder loggerBuilder, Action<AndroidConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<AndroidDestination, AndroidConfiguration>(configureAction);
        }
    }
}