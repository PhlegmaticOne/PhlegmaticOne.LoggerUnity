namespace OpenMyGame.LoggerUnity.Runtime.Extensions
{
    internal static class StringExtensions
    {
        public static (int, int) CountBraces(this string value)
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

            return (countOpenBraces, countCloseBraces);
        }
        
        public static int CountOf(this string str, char value)
        {
            var count = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var item = str[i];
                
                if (item.Equals(value))
                {
                    count++;
                }
            }

            return count;
        }
    }
}