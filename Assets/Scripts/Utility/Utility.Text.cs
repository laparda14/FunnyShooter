using FunnyShooter.Core;
using System;
using System.Text;

public static partial class Utility {
    /// <summary>
    /// 字符串相关工具类
    /// </summary>
    public static class Text {
        [ThreadStatic]
        private static StringBuilder stringBuilder;
        private const int StringBuilderCapacity = 1024;

        public static string Format(string format, object arg0) {
            CheckStringBuilder();
            if (string.IsNullOrEmpty(format)) {
                throw new CustomException("Format is null or empty.");
            }
            stringBuilder.Clear();
            stringBuilder.AppendFormat(format, arg0);
            return stringBuilder.ToString();
        }

        public static string Format(string format, object arg0, object arg1) {
            CheckStringBuilder();
            if (string.IsNullOrEmpty(format)) {
                throw new CustomException("Format is null or empty.");
            }

            stringBuilder.Clear();
            stringBuilder.AppendFormat(format, arg0, arg1);
            return stringBuilder.ToString();
        }

        public static string Format(string format, object arg0, object arg1, object arg2) {
            CheckStringBuilder();
            if (string.IsNullOrEmpty(format)) {
                throw new CustomException("Format is null or empty.");
            }

            stringBuilder.Clear();
            stringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return stringBuilder.ToString();
        }

        public static string Format(string format, params object[] args) {
            CheckStringBuilder();
            if (string.IsNullOrEmpty(format)) {
                throw new CustomException("Format is null or empty.");
            }

            stringBuilder.Clear();
            stringBuilder.AppendFormat(format, args);
            return stringBuilder.ToString();
        }

        private static void CheckStringBuilder() {
            if (stringBuilder == null) {
                stringBuilder = new StringBuilder(StringBuilderCapacity);
            }
        }
    }
}