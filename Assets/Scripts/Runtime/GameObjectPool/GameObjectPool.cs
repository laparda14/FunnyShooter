using System.Collections.Generic;
using UnityEngine;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 对象池
    /// </summary>
    public class GameObjectPool {
        private GameObject prefab;
        private Queue<GameObject> unUsedObjs;
        private string prefName;
        private int count;

        public GameObjectPool(GameObject prefab) {
            unUsedObjs = new Queue<GameObject>();
            this.prefab = prefab;
            prefName = prefab.name;
        }

        public GameObject SpawnObj() {
            GameObject obj;
            if (unUsedObjs.Count <= 0) {
                obj = Object.Instantiate(prefab, GameObjectPoolManager.Instance.transform);
                obj.name = string.Format("{0}-{1}", prefName, ++count);
            } else {
                obj = unUsedObjs.Dequeue();
                obj.SetActive(true);
            }
            return obj;
        }

        public void RecycleObj(GameObject obj) {
            unUsedObjs.Enqueue(obj);
            obj.SetActive(false);
            if (obj.transform.parent != GameObjectPoolManager.Instance.transform) {
                obj.transform.SetParent(GameObjectPoolManager.Instance.transform);
            }
        }
    }
}