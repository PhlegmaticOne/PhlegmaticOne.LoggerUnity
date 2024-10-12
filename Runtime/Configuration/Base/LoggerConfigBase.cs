using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Base
{
    public abstract class LoggerConfigBase : ScriptableObject, IDefaultSetup
    {
        public abstract void SetupDefaults();
    }
}