using System.Collections.Generic;
using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 对象池管理者
    /// </summary>
    public class GameObjectPoolManager : MonoSingleton<GameObjectPoolManager> {
        private Dictionary<string, GameObjectPool> gameObjectPoolDict;

        protected override void Awake() {
            base.Awake();
            gameObjectPoolDict = new Dictionary<string, GameObjectPool>();
        }

        public T SpawnObj<T>(string prefabName) where T : Component {
            return SpawnObj(prefabName).GetComponent<T>();
        }

        public GameObject SpawnObj(string prefabName) {
            if (!gameObjectPoolDict.TryGetValue(prefabName, out GameObjectPool gameObjectPool)) {
                GameObject prefab = ResourcesManager.Instance.Load<GameObject>(prefabName, ResourcesType.Prefab);
                if (!prefab) {
                    Utility.Log.Error("GameObjectPoolMgr.RecycleObj：不存在这个对象池，无法生产，请检查是否添加到了GameObjectPoolMgr中");
                    return null;
                }
                gameObjectPool = new GameObjectPool(prefab);
                gameObjectPoolDict.Add(prefab.name, gameObjectPool);
            }
            return gameObjectPool.SpawnObj();
        }

        public void RecycleObj(GameObject obj) {
            string objName = obj.name;
            string prefabName = objName.Substring(0, objName.IndexOf('-'));

            if (gameObjectPoolDict.TryGetValue(prefabName, out GameObjectPool GameObjectPool)) {
                GameObjectPool.RecycleObj(obj);
            } else {
                Utility.Log.Debug("不存在这个对象池，无法回收：'{0}'", prefabName);
            }
        }
    }
}