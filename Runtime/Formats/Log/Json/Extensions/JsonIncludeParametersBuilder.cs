using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    /// <summary>
    /// Класс для добавления параметров, используемых при построении JSON-сообщения
    /// </summary>
    public class JsonIncludeParametersBuilder
    {
        private readonly List<MessagePart> _parameters;
        
        public JsonIncludeParametersBuilder()
        {
            _parameters = new List<MessagePart>();
            Parameter(LogFormatParameterMessage.KeyParameter);
            Parameter(LogFormatParameterException.KeyParameter);
        }

        /// <summary>
        /// Добавляет новый параметр с список
        /// </summary>
        /// <example>LogLevel:u3</example>
        public void Parameter(string parameterValue)
        {
            var parameter = MessagePart.Parameter(parameterValue);
            _parameters.Add(parameter);
        }

        internal MessagePart[] GetParameters()
        {
            return _parameters.ToArray();
        }
    }
}