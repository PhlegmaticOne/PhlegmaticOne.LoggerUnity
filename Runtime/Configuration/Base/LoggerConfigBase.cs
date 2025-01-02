using UnityEngine;

namespace Openmygame.Logger.Configuration.Base
{
    public abstract class LoggerConfigBase : ScriptableObject, IDefaultSetup
    {
        public abstract void SetupDefaults();
    }
}