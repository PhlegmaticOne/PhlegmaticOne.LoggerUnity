using System;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class SerializeReferenceDropdownNameAttribute : PropertyAttribute
    {
        public string Name { get; }

        public SerializeReferenceDropdownNameAttribute(string name)
        {
            Name = name;
        }
    }
}