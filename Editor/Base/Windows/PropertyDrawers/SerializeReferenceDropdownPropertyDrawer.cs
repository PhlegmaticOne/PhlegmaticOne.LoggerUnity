using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Helpers;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SerializeReferenceDropdownAttribute))]
    internal class SerializeReferenceDropdownPropertyDrawer : PropertyDrawer
    {
        private const string NullName = "null";

        private List<Type> _assignableTypes;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            _assignableTypes ??= GetAssignableTypes(property);
            
            EditorGUI.BeginProperty(rect, label, property);

            if (property.propertyType == SerializedPropertyType.ManagedReference)
            {
                DrawImplementationsDropdown(rect, property, label);
            }
            else
            {
                EditorGUI.PropertyField(rect, property, label, true);
            }

            EditorGUI.EndProperty();
        }
        
        private void DrawImplementationsDropdown(Rect rect, SerializedProperty property, GUIContent label)
        {
            var referenceType = ReflectionHelper.ExtractTypeFromString(property.managedReferenceFullTypename);
            var dropdownRect = GetDropdownRect(rect);

            EditorGUI.EndDisabledGroup();

            var dropdownTypeContent = new GUIContent(text: GetTypeName(referenceType));
            
            if (EditorGUI.DropdownButton(dropdownRect, dropdownTypeContent, FocusType.Keyboard))
            {
                var dropdown = new AdvancedDropdown(new AdvancedDropdownState(),
                    _assignableTypes.Select(GetTypeName),
                    index => WriteNewInstanceByIndexType(index, property));
                dropdown.Show(dropdownRect);
            }

            EditorGUI.PropertyField(rect, property, label, true);
        }

        private static string GetTypeName(Type type)
        {
            if (type == null)
            {
                return NullName;
            }

            var typesWithNames = TypeCache.GetTypesWithAttribute(typeof(SerializeReferenceDropdownNameAttribute));
            
            if (typesWithNames.Contains(type))
            {
                var dropdownNameAttribute = type.GetCustomAttribute<SerializeReferenceDropdownNameAttribute>();
                return dropdownNameAttribute.Name;
            }

            return ObjectNames.NicifyVariableName(type.Name);
        }
        
        private static List<Type> GetAssignableTypes(SerializedProperty property)
        {
            var propertyType = ReflectionHelper.ExtractTypeFromString(property.managedReferenceFieldTypename);
            var derivedTypes = TypeCache.GetTypesDerivedFrom(propertyType);
            var nonUnityTypes = derivedTypes.Where(ReflectionHelper.IsFinalNonUnityType).ToList();
            nonUnityTypes.Insert(0, null);
            return nonUnityTypes;
        }

        private static Rect GetDropdownRect(Rect mainRect)
        {
            var dropdownOffset = EditorGUIUtility.labelWidth;
            var resultRect = new Rect(mainRect);
            resultRect.width -= dropdownOffset;
            resultRect.x += dropdownOffset;
            resultRect.height = EditorGUIUtility.singleLineHeight;
            return resultRect;
        }

        private void WriteNewInstanceByIndexType(int typeIndex, SerializedProperty property)
        {
            var newType = _assignableTypes[typeIndex];
            object newObject;
            
            if (newType?.GetConstructor(Type.EmptyTypes) != null)
            {
                newObject = Activator.CreateInstance(newType);
            }
            else
            {
                newObject = newType != null ? FormatterServices.GetUninitializedObject(newType) : null;
            }

            if (newObject is IDefaultSetup defaultSetup)
            {
                defaultSetup.SetupDefaults();
            }

            property.managedReferenceValue = newObject;
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
        }
    }
}