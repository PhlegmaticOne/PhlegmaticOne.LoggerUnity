using System.Buffers;

namespace OpenMyGame.LoggerUnity.Infrastructure.Extensions
{
    internal static class ArrayExtensions
    {
        public static object[] PrependValue(this object[] array, object value)
        {
            var rent = ArrayPool<object>.Shared.Rent(array.Length + 1);
            rent[0] = value;
            array.CopyTo(rent, 1);
            return rent;
        }
    }
}