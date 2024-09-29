namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class ArrayExtensions
    {
        public static T[] PrependValue<T>(this T[] array, T value)
        {
            var result = new T[array.Length + 1];
            result[0] = value;
            array.CopyTo(result, 1);
            return result;
        }
    }
}