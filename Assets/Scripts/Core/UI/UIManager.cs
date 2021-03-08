using System.Collections.Generic;
using UnityEngine;

namespace FunnyShooter.Core {
    public class UIManager : MonoSingleton<UIManager> {
        public Canvas canvas;
        private Dictionary<string, UIWindowBase> allUIWindows;
        private Dictionary<int, Transform> allUINodes;

        protected override void Awake() {
            base.Awake();
            allUIWindows = new Dictionary<string, UIWindowBase>();
            allUINodes = new Dictionary<int, Transform>();
            CreatUINode();
        }

        private void CreatUINode() {
            if (!canvas) {
                Utility.Log.Error("Canvas is null");
                return;
            }
            if (!transform.Find("FullScreen")) {
                Transform trs = new GameObject("FullScreen").transform;
                trs.SetParent(canvas.transform);
                allUINodes.Add((int)UIWindowType.FullScreen, trs);
            }
            if (!transform.Find("PopUp")) {
                Transform trs = new GameObject("PopUp").transform;
                trs.SetParent(canvas.transform);
                allUINodes.Add((int)UIWindowType.PopUp, trs);
            }
            if (!transform.Find("Fix")) {
                Transform trs = new GameObject("Fix").transform;
                trs.SetParent(canvas.transform);
                allUINodes.Add((int)UIWindowType.Fix, trs);
            }
        }

        public void CreatWindow(string windowName, UIWindowType windowType = UIWindowType.FullScreen, UIData data = null) {
            UIWindowBase windowBase = ResourcesManager.Instance.Load<UIWindowBase>(windowName);
            if (!windowBase) {
                Utility.Log.Error("This window {0} is not exist", windowName);
                return;
            }
            Transform parent = allUINodes[(int)windowType];
            Instantiate(windowBase, parent);
        }

        public void CloseWindow(string windowName) {
            
        }
    }
}