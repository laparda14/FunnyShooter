namespace FunnyShooter.Core {
    public class UIData : IReference {
        public string WindowName { get; protected set; }
        public UIWindowType WindowType { get; protected set; }

        public static UIData Creat(string windowName, UIWindowType windowType) {
            UIData data = ReferencePool.Acquire<UIData>();
            data.WindowName = windowName;
            data.WindowType = windowType;
            return data;
        }

        public virtual void Clear() {
            WindowName = null;
            WindowType = UIWindowType.FullScreen;
        }
    }

    public class UIData<T> : UIData {
        public T Item { get; private set; }

        public static UIData Creat(string windowName, UIWindowType windowType, T item) {
            UIData<T> data = ReferencePool.Acquire<UIData<T>>();
            data.WindowName = windowName;
            data.WindowType = windowType;
            data.Item = item;
            return data;
        }

        public override void Clear() {
            WindowName = null;
            WindowType = UIWindowType.FullScreen;
            Item = default(T);
        }
    }

    public class UIData<T1, T2> : UIData {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }

        public static UIData Creat(string windowName, UIWindowType windowType, T1 item1, T2 item2) {
            UIData<T1, T2> data = ReferencePool.Acquire<UIData<T1, T2>>();
            data.WindowName = windowName;
            data.WindowType = windowType;
            data.Item1 = item1;
            data.Item2 = item2;
            return data;
        }

        public override void Clear() {
            WindowName = null;
            WindowType = UIWindowType.FullScreen;
            Item1 = default(T1);
            Item2 = default(T2);
        }
    }

    public class UIData<T1, T2, T3> : UIData {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }

        public static UIData Creat(string windowName, UIWindowType windowType, T1 item1, T2 item2, T3 item3) {
            UIData<T1, T2, T3> data = ReferencePool.Acquire<UIData<T1, T2, T3>>();
            data.WindowName = windowName;
            data.WindowType = windowType;
            data.Item1 = item1;
            data.Item2 = item2;
            data.Item3 = item3;
            return data;
        }

        public override void Clear() {
            WindowName = null;
            WindowType = UIWindowType.FullScreen;
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
        }
    }
}