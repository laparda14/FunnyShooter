using System.Collections.Generic;
using UnityEngine;

namespace FunnyShooter.Core {
    public class ResourcesManager : Singleton<ResourcesManager> {
        private Dictionary<string, Object> objPool;

        public ResourcesManager() {
            objPool = new Dictionary<string, Object>();
        }

        public T Load<T>(string path) where T : Object {
            if (!objPool.TryGetValue(path, out Object obj)) {
                T item = Resources.Load<T>(path);
                if (!item) {
                    Utility.Log.Error("Path '{0}' is invalid", path);
                    return default(T);
                }
                objPool.Add(path, item);
                return item;
            } else {
                return obj as T;
            }
        }

        public T Load<T>(string path, ResourcesType type) where T : Object {
            return Load<T>(Utility.Text.Format("{0}/{1}", type.ToString(), path));
        }
    }

    public enum ResourcesType {
        Prefab,
        Window,
    }
}