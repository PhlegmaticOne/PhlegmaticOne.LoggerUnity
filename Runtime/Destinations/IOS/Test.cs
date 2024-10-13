using UnityEngine;

#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace OpenMyGame.LoggerUnity.Destinations.IOS
{
    public class Test : MonoBehaviour
    {
#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Debug(string tag, string message);
        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Warning(string tag, string message);
        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Error(string tag, string message);
        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Fatal(string tag, string message);
#endif

        private void Start()
        {
            Log("Test", "Message");
        }
        
        private void Log(string tagValue, string message)
        {
#if UNITY_IOS
            NativeLoggerIos_Debug(tagValue, message);
#endif
        }
    }
}