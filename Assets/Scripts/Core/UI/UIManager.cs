using System.Collections.Generic;
using UnityEngine;

namespace FunnyShooter.Core {
    public class UIManager : MonoSingleton<UIManager> {
        public Canvas canvas;
        private Dictionary<string, UIWindowBase> allUIWindows;
        private Dictionary<string, UIWindowBase> showUIWindows;
        private Dictionary<int, Transform> allUINodes;

        protected override void Awake() {
            base.Awake();
            allUIWindows = new Dictionary<string, UIWindowBase>();
            showUIWindows = new Dictionary<string, UIWindowBase>();
            allUINodes = new Dictionary<int, Transform>();
            CreatUINode();
        }

        private void CreatUINode() {
            if (!canvas) {
                Utility.Log.Error("Canvas is null");
                return;
            }
            if (!transform.Find("FullScreen")) {
                RectTransform rectTrs = new GameObject("FullScreen").AddComponent<RectTransform>();
                rectTrs.SetParent(canvas.transform);
                rectTrs.StretchToFullScreen();
                rectTrs.LocalReset();
                allUINodes.Add((int)UIWindowType.FullScreen, rectTrs);
            }
            if (!transform.Find("PopUp")) {
                RectTransform rectTrs = new GameObject("PopUp").AddComponent<RectTransform>();
                rectTrs.SetParent(canvas.transform);
                rectTrs.StretchToFullScreen();
                rectTrs.LocalReset();
                allUINodes.Add((int)UIWindowType.PopUp, rectTrs);
            }
            if (!transform.Find("Fix")) {
                RectTransform rectTrs = new GameObject("Fix").AddComponent<RectTransform>();
                rectTrs.SetParent(canvas.transform);
                rectTrs.StretchToFullScreen();
                rectTrs.LocalReset();
                allUINodes.Add((int)UIWindowType.Fix, rectTrs);
            }
        }

        public void ShowWindow(string windowName, UIWindowType windowType = UIWindowType.FullScreen) {
            UIData data = UIData.Creat(windowName, windowType);
            ShowWindow(data);
        }

        public void ShowWindow(UIData data) {
            if (data == null) {
                Utility.Log.Error("UI data is invalid", data.WindowName);
                return;
            }
            string windowName = data.WindowName;
            UIWindowType windowType = data.WindowType;
            UIWindowBase windowPrefab = ResourcesManager.Instance.Load<UIWindowBase>(windowName, ResourcesType.Window);
            if (!windowPrefab) {
                Utility.Log.Error("This window '{0}' is not exist", windowName);
                ReferencePool.Release(data);
                return;
            }
            if (!allUIWindows.TryGetValue(windowName, out UIWindowBase windowBase)) {
                Transform parent = allUINodes[(int)windowType];
                windowBase = Instantiate(windowPrefab, parent);
                windowBase.transform.LocalReset();
                allUIWindows.Add(windowName, windowBase);
                windowBase.InitData(data);
                windowBase.OnCreatWindow();
            } else {
                if (showUIWindows.ContainsKey(windowName)) {
                    Utility.Log.Error("This window '{0}' is already show", windowName);
                    return;
                }
                windowBase.gameObject.SetActive(true);
                windowBase.InitData(data);
                windowBase.OnShowWindow();
            }
            windowBase.transform.SetAsLastSibling();
            showUIWindows.Add(windowName, windowBase);
        }

        public void HideWindow(string windowName) {
            if (showUIWindows.TryGetValue(windowName, out UIWindowBase windowBase)) {
                windowBase.gameObject.SetActive(false);
                windowBase.OnHideWindow();
                showUIWindows.Remove(windowName);
            } else {
                Utility.Log.Error("this window '{0}' is not exist in show windows", windowName);
            }
        }

        /// <summary>
        /// 注意只有显示在面板上的窗口才能关闭
        /// </summary>
        /// <param name="windowName"></param>
        public void CloseWindow(string windowName) {
            if (showUIWindows.TryGetValue(windowName, out UIWindowBase windowBase)) {
                showUIWindows.Remove(windowName);
                allUIWindows.Remove(windowName);
                windowBase.OnCloseWindow();
                Destroy(windowBase.gameObject);
            } else {
                Utility.Log.Error("this window '{0}' is not exist in show windows", windowName);
            }
        }

        /// <summary>
        /// 注意会关闭所有窗口包括隐藏的
        /// </summary>
        public void CloseAllWindow() {
            foreach(UIWindowBase windowBase in allUIWindows.Values) {
                windowBase.OnCloseWindow();
            }
            allUIWindows.Clear();
            showUIWindows.Clear();
        }

        public bool HasWindow(string windowName) {
            return showUIWindows.ContainsKey(windowName);
        }

        public UIWindowBase GetWindow(string windowName) {
            allUIWindows.TryGetValue(windowName, out UIWindowBase windowBase);
            return windowBase;
        }
    }
}