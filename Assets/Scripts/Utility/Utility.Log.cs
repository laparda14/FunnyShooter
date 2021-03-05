using System.Diagnostics;

public static partial class Utility {
    public static class Log {

        [Conditional("DEBUG")]
        public static void Debug(object message) {
            UnityEngine.Debug.Log(message);
        }

        [Conditional("DEBUG")]
        public static void Debug(string message) {
            UnityEngine.Debug.Log(message);
        }

        [Conditional("DEBUG")]
        public static void Debug(string format, params object[] args) {
            UnityEngine.Debug.LogFormat(format, args);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        public static void Wanning(object message) {
            UnityEngine.Debug.LogWarning(message);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        public static void Wanning(string message) {
            UnityEngine.Debug.LogWarning(message);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        public static void Wanning(string format, params object[] args) {
            UnityEngine.Debug.LogWarningFormat(format, args);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        [Conditional("ERROR")]
        public static void Error(object message) {
            UnityEngine.Debug.LogError(message);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        [Conditional("ERROR")]
        public static void Error(string message) {
            UnityEngine.Debug.LogError(message);
        }

        [Conditional("DEBUG")]
        [Conditional("WANNING")]
        [Conditional("ERROR")]
        public static void Error(string format, params object[] args) {
            UnityEngine.Debug.LogErrorFormat(format, args);
        }
    }
}