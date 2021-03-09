using UnityEngine;
using SystemMath = System.Math;
using UnityMath = UnityEngine.Mathf;

public static partial class Utility {
    /// <summary>
    /// 数学库工具类
    /// </summary>
    public static class Math {

        public static bool Approximately(float a, float b) {
            return SystemMath.Abs(a - b) < float.Epsilon;
        }

        public static bool Approximately(Vector2 a, Vector2 b) {
            return SystemMath.Abs(a.x - b.x) < float.Epsilon
                && SystemMath.Abs(a.y - b.y) < float.Epsilon;
        }

        public static int Clamp(int value, int min, int max) {
            return UnityMath.Clamp(value, min, max);
        }

        public static float Clamp(float value,float min,float max) {
            return UnityMath.Clamp(value, min, max);
        }

        public static float Clamp01(float value) {
            return UnityMath.Clamp01(value);
        }
    }
}