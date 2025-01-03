﻿using System;

namespace Openmygame.Logger.Configuration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class LoggerConfigMetadataAttribute : Attribute
    {
        public string ConfigName { get; }
        public string CreateDescription { get; }
        public int OrderInEditor { get; }

        public LoggerConfigMetadataAttribute(string configName, string createDescription, int orderInEditor)
        {
            ConfigName = configName;
            CreateDescription = createDescription;
            OrderInEditor = orderInEditor;
        }
    }
}