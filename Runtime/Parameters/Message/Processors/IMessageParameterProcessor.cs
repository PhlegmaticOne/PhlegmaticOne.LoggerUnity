using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    public interface IMessageParameterProcessor
    {
        void Preprocess(ref ValueStringBuilder destination, object parameter);
        void Postprocess(ref ValueStringBuilder destination, object parameter);
    }
}