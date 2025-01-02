using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parameters.Message.Processors;

namespace Openmygame.Logger.Destinations.UnityDebug.Colors
{
    internal class MessageParameterProcessorColorize : IMessageParameterProcessor
    {
        private readonly IParameterColorsViewConfig _colorsViewConfig;

        public MessageParameterProcessorColorize(IParameterColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }

        public void Preprocess(ref ValueStringBuilder destination, object parameter)
        {
            var color = parameter is LogTag tag
                ? _colorsViewConfig.GetTagColor(tag.Value)
                : _colorsViewConfig.GetMessageParameterColor(parameter);

            destination.AppendColorPrefix(color);
        }

        public void Postprocess(ref ValueStringBuilder destination, object parameter)
        {
            destination.AppendColorPostfix();
        }
    }
}