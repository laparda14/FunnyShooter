using UnityEngine;

namespace FunnyShooter.Core {
    public class ResourcesManager : Singleton<ResourcesManager> {

        public T Load<T>(string path) where T : Object {
            return Resources.Load<T>(path);
        }
    }
}