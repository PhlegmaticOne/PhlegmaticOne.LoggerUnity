using System;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Base
{
    /// <summary>
    /// Интерфейс для создания параметров сообщений с кастомным типом
    /// </summary>
    public interface IMessageFormatParameter
    {
        /// <summary>
        /// Тип параметра
        /// </summary>
        Type PropertyType { get; }
        
        /// <summary>
        /// Возвращает отрендеренное значение параметра
        /// </summary>
        /// <param name="parameter">Значение параметра</param>
        /// <param name="format">Формат, указанный в сообщении</param>
        ReadOnlySpan<char> Render(object parameter, ReadOnlySpan<char> format);
    }
}