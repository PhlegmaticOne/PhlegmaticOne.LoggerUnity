namespace OpenMyGame.LoggerUnity.Runtime.Messages
{
    public abstract class LogParameter
    {
        protected LogParameter(string key)
        {
            Key = key;
        }

        public string Key { get; }
        public abstract string Render();
    }
}