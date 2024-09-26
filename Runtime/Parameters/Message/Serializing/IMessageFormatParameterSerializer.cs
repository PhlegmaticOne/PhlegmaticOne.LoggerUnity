namespace OpenMyGame.LoggerUnity.Parameters.Message.Serializing
{
    public interface IMessageFormatParameterSerializer
    {
        string Serialize(object value);
    }
}