using System;
using FunnyShooter.Core;
using FunnyShooter.Runtime;

public static partial class Utility {
    public static class Event {
        #region Subscribe And Unsubscribe

        public static void Subscribe(GameEventId id, EventHandler<GameEventArgs> handler) {
            EventManager.Instance.Subscribe((int)id, handler);
        }

        public static void Unsubscribe(GameEventId id, EventHandler<GameEventArgs> handler) {
            EventManager.Instance.Unsubscribe((int)id, handler);
        }

        #endregion

        #region Fire

        public static void Fire(GameEventId id) {
            GenericEventArgs args = GenericEventArgs.Creat((int)id);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T>(GameEventId id, T item) {
            GenericEventArgs<T> args = GenericEventArgs<T>.Creat((int)id, item);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2>(GameEventId id, T1 item1, T2 item2) {
            GenericEventArgs<T1, T2> args = GenericEventArgs<T1, T2>.Creat((int)id, item1, item2);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3>(GameEventId id, T1 item1, T2 item2, T3 item3) {
            GenericEventArgs<T1, T2, T3> args = GenericEventArgs<T1, T2, T3>.Creat((int)id, item1, item2, item3);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4) {
            GenericEventArgs<T1, T2, T3, T4> args = GenericEventArgs<T1, T2, T3, T4>.Creat((int)id, item1, item2, item3, item4);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4, T5>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) {
            GenericEventArgs<T1, T2, T3, T4, T5> args = GenericEventArgs<T1, T2, T3, T4, T5>.Creat((int)id, item1, item2, item3, item4, item5);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6> args = GenericEventArgs<T1, T2, T3, T4, T5, T6>.Creat((int)id, item1, item2, item3, item4, item5, item6);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7, T8>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8);
            EventManager.Instance.Fire(args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7, T8, T9>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8, item9);
            EventManager.Instance.Fire(args);
        }

        public static void Fire(object sender, GameEventId id) {
            GenericEventArgs args = GenericEventArgs.Creat((int)id);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T>(object sender, GameEventId id, T item) {
            GenericEventArgs<T> args = GenericEventArgs<T>.Creat((int)id, item);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2>(object sender, GameEventId id, T1 item1, T2 item2) {
            GenericEventArgs<T1, T2> args = GenericEventArgs<T1, T2>.Creat((int)id, item1, item2);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3) {
            GenericEventArgs<T1, T2, T3> args = GenericEventArgs<T1, T2, T3>.Creat((int)id, item1, item2, item3);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4) {
            GenericEventArgs<T1, T2, T3, T4> args = GenericEventArgs<T1, T2, T3, T4>.Creat((int)id, item1, item2, item3, item4);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4, T5>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) {
            GenericEventArgs<T1, T2, T3, T4, T5> args = GenericEventArgs<T1, T2, T3, T4, T5>.Creat((int)id, item1, item2, item3, item4, item5);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6> args = GenericEventArgs<T1, T2, T3, T4, T5, T6>.Creat((int)id, item1, item2, item3, item4, item5, item6);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7, T8>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8);
            EventManager.Instance.Fire(sender, args);
        }

        public static void Fire<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8, item9);
            EventManager.Instance.Fire(sender, args);
        }

        #endregion

        #region FireNew

        public static void FireNow(GameEventId id) {
            GenericEventArgs args = GenericEventArgs.Creat((int)id);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T>(GameEventId id, T item) {
            GenericEventArgs<T> args = GenericEventArgs<T>.Creat((int)id, item);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2>(GameEventId id, T1 item1, T2 item2) {
            GenericEventArgs<T1, T2> args = GenericEventArgs<T1, T2>.Creat((int)id, item1, item2);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3>(GameEventId id, T1 item1, T2 item2, T3 item3) {
            GenericEventArgs<T1, T2, T3> args = GenericEventArgs<T1, T2, T3>.Creat((int)id, item1, item2, item3);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4) {
            GenericEventArgs<T1, T2, T3, T4> args = GenericEventArgs<T1, T2, T3, T4>.Creat((int)id, item1, item2, item3, item4);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4, T5>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) {
            GenericEventArgs<T1, T2, T3, T4, T5> args = GenericEventArgs<T1, T2, T3, T4, T5>.Creat((int)id, item1, item2, item3, item4, item5);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6> args = GenericEventArgs<T1, T2, T3, T4, T5, T6>.Creat((int)id, item1, item2, item3, item4, item5, item6);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7, T8>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7, T8, T9>(GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8, item9);
            EventManager.Instance.FireNow(args);
        }

        public static void FireNow(object sender, GameEventId id) {
            GenericEventArgs args = GenericEventArgs.Creat((int)id);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T>(object sender, GameEventId id, T item) {
            GenericEventArgs<T> args = GenericEventArgs<T>.Creat((int)id, item);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2>(object sender, GameEventId id, T1 item1, T2 item2) {
            GenericEventArgs<T1, T2> args = GenericEventArgs<T1, T2>.Creat((int)id, item1, item2);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3) {
            GenericEventArgs<T1, T2, T3> args = GenericEventArgs<T1, T2, T3>.Creat((int)id, item1, item2, item3);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4) {
            GenericEventArgs<T1, T2, T3, T4> args = GenericEventArgs<T1, T2, T3, T4>.Creat((int)id, item1, item2, item3, item4);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4, T5>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) {
            GenericEventArgs<T1, T2, T3, T4, T5> args = GenericEventArgs<T1, T2, T3, T4, T5>.Creat((int)id, item1, item2, item3, item4, item5);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6> args = GenericEventArgs<T1, T2, T3, T4, T5, T6>.Creat((int)id, item1, item2, item3, item4, item5, item6);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7, T8>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8);
            EventManager.Instance.FireNow(sender, args);
        }

        public static void FireNow<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object sender, GameEventId id, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9) {
            GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9> args = GenericEventArgs<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Creat((int)id, item1, item2, item3, item4, item5, item6, item7, item8, item9);
            EventManager.Instance.FireNow(sender, args);
        }

        #endregion
    }
}