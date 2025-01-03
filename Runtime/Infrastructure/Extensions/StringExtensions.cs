namespace Openmygame.Logger.Infrastructure.Extensions
{
    internal readonly struct BracesCount
    {
        public readonly int CountOpenBraces;
        public readonly int CountCloseBraces;

        public BracesCount(int countOpenBraces, int countCloseBraces)
        {
            CountOpenBraces = countOpenBraces;
            CountCloseBraces = countCloseBraces;
        }
    }
    
    internal static class StringExtensions
    {
        public static BracesCount CountBraces(this string value)
        {
            var countOpenBraces = 0;
            var countCloseBraces = 0;

            for (var i = 0; i < value.Length; i++)
            {
                var item = value[i];

                switch (item)
                {
                    case '{':
                        countOpenBraces++;
                        break;
                    case '}':
                        countCloseBraces++;
                        break;
                }
            }

            return new BracesCount(countOpenBraces, countCloseBraces);
        }
    }
}