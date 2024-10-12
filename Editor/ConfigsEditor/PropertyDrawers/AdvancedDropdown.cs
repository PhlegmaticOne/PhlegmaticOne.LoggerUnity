using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.PropertyDrawers
{
    internal class AdvancedDropdown : UnityEditor.IMGUI.Controls.AdvancedDropdown
    {
        private readonly IEnumerable<string> _typeNames;
        private readonly Dictionary<AdvancedDropdownItem, int> _itemAndIndexes;
        private readonly Action<int> _onSelectedTypeIndex;

        public AdvancedDropdown(
            AdvancedDropdownState state, IEnumerable<string> typeNames, Action<int> onSelectedNewType) : base(state)
        {
            _typeNames = typeNames;
            _onSelectedTypeIndex = onSelectedNewType;
            _itemAndIndexes = new Dictionary<AdvancedDropdownItem, int>();
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem("Types");
            _itemAndIndexes.Clear();

            var index = 0;
            
            foreach (var typeName in _typeNames)
            {
                var item = new AdvancedDropdownItem(typeName);
                _itemAndIndexes.Add(item, index);
                root.AddChild(item);
                index++;
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            base.ItemSelected(item);
            
            if (_itemAndIndexes.TryGetValue(item, out var index))
            {
                _onSelectedTypeIndex.Invoke(index);
            }
        }
    }
}