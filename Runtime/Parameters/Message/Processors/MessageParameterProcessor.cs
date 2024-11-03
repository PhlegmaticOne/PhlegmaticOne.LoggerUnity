using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    internal class MessageParameterProcessor : IMessageParameterProcessor
    {
        public void Preprocess(ref ValueStringBuilder destination, object parameter) { }
        public void Postprocess(ref ValueStringBuilder destination, object parameter) { }
    }
}