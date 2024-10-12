using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Formats;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Rendering
{
    public abstract class LogMessageRenderBuilder : IDefaultSetup
    {
        public abstract void Build(RenderMessageOptions renderMessageOptions);
        public virtual void SetupDefaults() { }
    }
}