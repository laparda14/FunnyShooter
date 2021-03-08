using System.Collections.Generic;
using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 对象池管理者
    /// </summary>
    public class GameObjectPoolManager : MonoSingleton<GameObjectPoolManager> {
        [Header("需要池子管理的实体")]
        public GameObject[] prefabs;

        private readonly Dictionary<string, GameObjectPool> gameObjectPoolDict = new Dictionary<string, GameObjectPool>();

        private void Start() {
            foreach (GameObject pref in prefabs) {
                string key = pref.name;

                if (!gameObjectPoolDict.ContainsKey(key)) {
                    GameObjectPool GameObjectPool = new GameObjectPool(pref);
                    gameObjectPoolDict.Add(pref.name, GameObjectPool);
                } else {
                    Utility.Log.Debug("已经存在同名的对象池：{0}", key);
                }
            }
        }

        public T SpawnObj<T>(string prefName) where T : Component {
            return SpawnObj(prefName).GetComponent<T>();
        }

        public GameObject SpawnObj(string prefName) {
            if (gameObjectPoolDict.TryGetValue(prefName, out GameObjectPool GameObjectPool)) {
                return GameObjectPool.SpawnObj();
            } else {
                throw new CustomException("GameObjectPoolMgr.RecycleObj：不存在这个对象池，无法生产，请检查是否添加到了GameObjectPoolMgr中");
            }
        }

        public void RecycleObj(GameObject obj) {
            string objName = obj.name;
            string prefName = objName.Substring(0, objName.IndexOf('-'));

            if (gameObjectPoolDict.TryGetValue(prefName, out GameObjectPool GameObjectPool)) {
                GameObjectPool.RecycleObj(obj);
            } else {
                Utility.Log.Debug("不存在这个对象池，无法回收：{0}", prefName);
            }
        }
    }
}