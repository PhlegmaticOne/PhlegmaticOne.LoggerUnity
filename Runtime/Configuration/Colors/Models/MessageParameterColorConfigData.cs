﻿using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Colors.Models
{
    [Serializable]
    public struct MessageParameterColorConfigData
    {
        [SerializeReference, SerializeReferenceDropdown]
        private IMessageFormatParameter _messageParameter;
        [SerializeField] private Color _color;

        public MessageParameterColorConfigData(IMessageFormatParameter messageParameter, Color color)
        {
            _messageParameter = messageParameter;
            _color = color;
        }

        public Type ParameterType => _messageParameter.PropertyType;
        public Color Color => _color;

        public bool ContainsData()
        {
            return _messageParameter is not null;
        }

        public override string ToString()
        {
            return _messageParameter.PropertyType.Name;
        }
    }
}