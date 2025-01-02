﻿using System;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class SerializeReferenceDropdownNameAttribute : PropertyAttribute
    {
        public string Name { get; }

        public SerializeReferenceDropdownNameAttribute(string name)
        {
            Name = name;
        }
    }
}