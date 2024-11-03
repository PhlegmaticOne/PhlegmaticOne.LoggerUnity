using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogConfiguration : LogConfiguration
    {
        private int _messagePartMaxSize;
        private string _messagePartFormat;
        
        public UnityDebugLogConfiguration()
        {
            MessagePartMaxSize = UnityDebugLogStaticData.MessagePartMaxSize;
            MessagePartFormat = UnityDebugLogStaticData.MessagePartFormat;
            IsUnityStacktraceEnabled = UnityDebugLogStaticData.IsUnityStacktraceEnabled;
            Platform = LoggerPlatform.Editor | LoggerPlatform.Android | LoggerPlatform.Ios;
        }

        /// <summary>
        /// Включает или выключает формирование стектрейса от Unity
        /// </summary>
        public bool IsUnityStacktraceEnabled { get; set; }

        /// <summary>
        /// Устанавливает максимальный размер сообщения, после которого начинается его разбиение на части
        /// </summary>
        /// <exception cref="ArgumentException">Размер меньше 0</exception>
        public int MessagePartMaxSize
        {
            get => _messagePartMaxSize;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Message part max size cannot be less than zero", nameof(MessagePartMaxSize));
                }

                _messagePartMaxSize = value;
            }
        }

        /// <summary>
        /// Устаналивает формат для формирования частей сообщения при его разбиении
        /// </summary>
        /// <remarks>Должно содержать параметры: MessageId, PartIndex, PartsCount, MessagePart - или часть из них</remarks>
        /// <example>[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}</example>
        /// <exception cref="ArgumentException">Формат null или пустая строка</exception>
        public string MessagePartFormat
        {
            get => _messagePartFormat;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Message part format cannot be an empty string", nameof(MessagePartFormat));
                }

                _messagePartFormat = value;
            }
        }

        /// <summary>
        /// Включает раскрашивание параметров при логгировании при помощи тега <i>color</i> с дефолтным конфигом
        /// </summary>
        public void ColorizeParameters()
        {
            ColorizeParameters(new ParameterColorsViewConfigDefault());
        }
        
        /// <summary>
        /// Включает раскрашивание параметров при логгировании при помощи тега <i>color</i> с кастомным конфигом
        /// </summary>
        public void ColorizeParameters(IParameterColorsViewConfig colorsViewConfig)
        {
            SetMessageParameterPostRenderer(new MessageParameterProcessorColorize(colorsViewConfig));
            SetLogParameterPostRenderer(new LogParameterProcessorColorize(colorsViewConfig));
        }
    }
}