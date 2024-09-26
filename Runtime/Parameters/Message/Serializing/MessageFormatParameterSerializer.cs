using Newtonsoft.Json;

namespace OpenMyGame.LoggerUnity.Properties.Message.Serializing
{
    internal class MessageFormatParameterSerializer : IMessageFormatParameterSerializer
    {
        private readonly JsonSerializerSettings _serializerSettings;
        
        public MessageFormatParameterSerializer()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None,
            };
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, _serializerSettings);
        }
    }
}