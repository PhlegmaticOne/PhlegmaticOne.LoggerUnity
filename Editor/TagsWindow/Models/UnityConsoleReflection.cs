using System;
using System.Reflection;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public class UnityConsoleReflection
    {
        private readonly object _consoleWindowInstance;
        private readonly MethodInfo _setFilterMethod;
        private readonly MethodInfo _repaintMethod;

        public UnityConsoleReflection()
        {
            var consoleWindowType = Assembly
                .GetAssembly(typeof(UnityEditor.Editor))
                .GetType("UnityEditor.ConsoleWindow");
            
            _consoleWindowInstance = consoleWindowType
                .GetField("ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic)!
                .GetValue(null);
            
            _setFilterMethod = consoleWindowType
                .GetMethod("SetFilter", BindingFlags.Instance | BindingFlags.NonPublic);
            
            _repaintMethod = consoleWindowType
                .GetMethod("Repaint", BindingFlags.Instance | BindingFlags.Public);
        }

        public void SetFilter(string filter)
        {
            _setFilterMethod.Invoke(_consoleWindowInstance, new object[] { filter });
            _repaintMethod.Invoke(_consoleWindowInstance, Array.Empty<object>());
        }
    }
}