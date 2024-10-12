using System;

namespace OpenMyGame.LoggerUnity.Configuration.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class LoggerConfigMetadataAttribute : Attribute
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