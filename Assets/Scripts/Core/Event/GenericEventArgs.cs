namespace FunnyShooter.Core {
    /// <summary>
    /// 泛型事件参数。
    /// </summary>
    public class GenericEventArgs : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public static GenericEventArgs Creat(int id) {
            GenericEventArgs args = ReferencePool.Acquire<GenericEventArgs>();
            args.Id = id;
            return args;
        }

        public override void Clear() {
            Id = default(int);
        }
    }

    public class GenericEventArgs<T> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T Item {
            get;
            protected set;
        }

        public static GenericEventArgs<T> Creat(int id, T item) {
            GenericEventArgs<T> args = ReferencePool.Acquire<GenericEventArgs<T>>();
            args.Id = id;
            args.Item = item;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item = default(T);
        }
    }

    public class GenericEventArgs<T1, T2> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2> Creat(int id, T1 item1, T2 item2) {
            GenericEventArgs<T1, T2> args = ReferencePool.Acquire<GenericEventArgs<T1, T2>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
        }
    }

    public class GenericEventArgs<T1, T2, T3> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3> Creat(int id, T1 item1, T2 item2, T3 item3) {
            GenericEventArgs<T1, T2, T3> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4) {
            GenericEventArgs<T1, T2, T3, T4> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4, T5> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public T5 Item5 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4, T5> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) {
            GenericEventArgs<T1, T2, T3, T4, T5> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4, T5>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            args.Item5 = item5;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
            Item5 = default(T5);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4, T5, T6> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public T5 Item5 {
            get;
            protected set;
        }

        public T6 Item6 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4, T5, T6> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4, T5, T6>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            args.Item5 = item5;
            args.Item6 = item6;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
            Item5 = default(T5);
            Item6 = default(T6);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public T5 Item5 {
            get;
            protected set;
        }

        public T6 Item6 {
            get;
            protected set;
        }

        public T7 Item7 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4, T5, T6, T7>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            args.Item5 = item5;
            args.Item6 = item6;
            args.Item7 = item7;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
            Item5 = default(T5);
            Item6 = default(T6);
            Item7 = default(T7);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public T5 Item5 {
            get;
            protected set;
        }

        public T6 Item6 {
            get;
            protected set;
        }

        public T7 Item7 {
            get;
            protected set;
        }

        public T8 Item8 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            args.Item5 = item5;
            args.Item6 = item6;
            args.Item7 = item7;
            args.Item8 = item8;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
            Item5 = default(T5);
            Item6 = default(T6);
            Item7 = default(T7);
            Item8 = default(T8);
        }
    }

    public class GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> : GameEventArgs {
        public override int Id {
            get;
            protected set;
        }

        public T1 Item1 {
            get;
            protected set;
        }

        public T2 Item2 {
            get;
            protected set;
        }

        public T3 Item3 {
            get;
            protected set;
        }

        public T4 Item4 {
            get;
            protected set;
        }

        public T5 Item5 {
            get;
            protected set;
        }

        public T6 Item6 {
            get;
            protected set;
        }

        public T7 Item7 {
            get;
            protected set;
        }

        public T8 Item8 {
            get;
            protected set;
        }

        public T9 Item9 {
            get;
            protected set;
        }

        public static GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> Creat(int id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> args = ReferencePool.Acquire<GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>>();
            args.Id = id;
            args.Item1 = item1;
            args.Item2 = item2;
            args.Item3 = item3;
            args.Item4 = item4;
            args.Item5 = item5;
            args.Item6 = item6;
            args.Item7 = item7;
            args.Item8 = item8;
            args.Item9 = item9;
            return args;
        }

        public override void Clear() {
            Id = default(int);
            Item1 = default(T1);
            Item2 = default(T2);
            Item3 = default(T3);
            Item4 = default(T4);
            Item5 = default(T5);
            Item6 = default(T6);
            Item7 = default(T7);
            Item8 = default(T8);
            Item9 = default(T9);
        }
    }
}
