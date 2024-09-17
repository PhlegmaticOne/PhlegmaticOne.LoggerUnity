using Newtonsoft.Json;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message.Serializing
{
    public class MessageFormatPropertySerializer : IMessageFormatPropertySerializer
    {
        private readonly JsonSerializerSettings _serializerSettings;
        
        public MessageFormatPropertySerializer()
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