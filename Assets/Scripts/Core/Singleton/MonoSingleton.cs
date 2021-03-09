using System;
using UnityEngine;

namespace FunnyShooter.Core {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
        private static T instance;

        public static T Instance {
            get {
                if (instance == null) {
                    Type type = typeof(T);
                    instance = FindObjectOfType<T>();
                    if (instance == null) {
                        instance = new GameObject(type.Name).AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake() {
            if (instance == null) {
                instance = this as T;
            } else if (instance != this) {
                Destroy(gameObject);
            }
        }
    }
}