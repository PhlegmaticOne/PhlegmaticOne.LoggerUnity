namespace OpenMyGame.LoggerUnity.Runtime.Extensions
{
    public static class StringExtensions
    {
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