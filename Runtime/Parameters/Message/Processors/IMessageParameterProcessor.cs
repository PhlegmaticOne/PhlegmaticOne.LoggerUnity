using Openmygame.Logger.Infrastructure.StringBuilders;

namespace Openmygame.Logger.Parameters.Message.Processors
{
    public interface IMessageParameterProcessor
    {
        void Preprocess(ref ValueStringBuilder destination, object parameter);
        void Postprocess(ref ValueStringBuilder destination, object parameter);
    }
}