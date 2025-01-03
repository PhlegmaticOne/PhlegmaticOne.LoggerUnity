using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parameters.Message.Processors;
using UnityEngine;

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
            destination.AppendColorPrefix(GetParameterColor(parameter));
        }

        public void Postprocess(ref ValueStringBuilder destination, object parameter)
        {
            destination.AppendColorPostfix();
        }

        private Color GetParameterColor(object parameter)
        {
            if (parameter is not Tag tag)
            {
                return _colorsViewConfig.GetMessageParameterColor(parameter);
            }

            return tag.IsSubsystem ? _colorsViewConfig.GetSubsystemColor() : _colorsViewConfig.GetTagColor(tag.Value);
        }
    }
}