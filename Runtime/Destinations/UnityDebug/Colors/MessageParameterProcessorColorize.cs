using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors
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