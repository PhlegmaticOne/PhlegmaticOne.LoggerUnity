using System;
using Newtonsoft.Json;

namespace Openmygame.Logger.Parameters.Message.Serializing
{
    internal class MessageFormatParameterSerializer : IMessageFormatParameterSerializer
    {
        private readonly JsonSerializerSettings _serializerSettingsNone;
        private readonly JsonSerializerSettings _serializerSettingsIndented;
        
        public MessageFormatParameterSerializer()
        {
            _serializerSettingsNone = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None,
            };

            _serializerSettingsIndented = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public string Serialize(object value, ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return SerializeCompact(value);
            }

            var formatChar = format[0];

            return formatChar switch
            {
                'c' => SerializeCompact(value),
                'f' => SerializeFull(value),
                _ => SerializeCompact(value)
            };
        }

        private string SerializeCompact(object value)
        {
            return JsonConvert.SerializeObject(value, _serializerSettingsNone);
        }

        private string SerializeFull(object value)
        {
            return JsonConvert.SerializeObject(value, _serializerSettingsIndented);
        }
    }
}