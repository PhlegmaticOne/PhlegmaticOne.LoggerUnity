using Openmygame.Logger.Configuration.Base;
using Openmygame.Logger.Formats;

namespace Openmygame.Logger.Configuration.Logger.Rendering
{
    public abstract class LogMessageRenderBuilder : IDefaultSetup
    {
        public abstract void Build(RenderMessageOptions renderMessageOptions);
        public virtual void SetupDefaults() { }
    }
}