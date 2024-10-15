using System;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    public static class RenderMessageOptionsExtensions
    {
        /// <summary>
        /// Конфигурирует параметры, используемые при построении JSON-сообщения
        /// </summary>
        public static void Json(this RenderMessageOptions messageOptions,
            Action<JsonIncludeParametersBuilder> builderAction = null)
        {
            var parametersBuilder = new JsonIncludeParametersBuilder();
            builderAction?.Invoke(parametersBuilder);
            var parameters = parametersBuilder.GetParameters();
            messageOptions.FromFactory(new LogFormatFactoryJson(parameters));
        }
    }
}