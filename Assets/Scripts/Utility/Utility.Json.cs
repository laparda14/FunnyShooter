using System;
using UnityEngine;

public static partial class Utility {
    /// <summary>
    /// Json 工具类
    /// </summary>
    public static partial class Json {

        public static string ToJson(object obj) {
            return JsonUtility.ToJson(obj);
        }

        public static T ToObject<T>(string json) {

            return JsonUtility.FromJson<T>(json);
        }

        public static object ToObject(string json, Type objectType) {
            return JsonUtility.FromJson(json, objectType);
        }
    }
}
