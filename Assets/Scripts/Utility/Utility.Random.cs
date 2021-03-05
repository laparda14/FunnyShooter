using System;
using SystemRandom = System.Random;

public static partial class Utility {
    /// <summary>
    /// 随机生成工具类。
    /// </summary>
    public static class Random {
        private static readonly SystemRandom random;

        static Random() {
            random = new SystemRandom((int)DateTime.UtcNow.Ticks);
        }

        public static int Next() {
            return random.Next();
        }

        public static int Next(int maxValue) {
            return random.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue) {
            return random.Next(minValue, maxValue);
        }

        public static void NextBytes(byte[] buffer) {
            random.NextBytes(buffer);
        }

        public static double NextDouble() {
            return random.NextDouble();
        }
    }
}