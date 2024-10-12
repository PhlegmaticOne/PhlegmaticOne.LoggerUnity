using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SerializeReferenceDropdownNameAttribute : PropertyAttribute
    {
        public string Name { get; }

        public SerializeReferenceDropdownNameAttribute(string name)
        {
            Name = name;
        }
    }
}