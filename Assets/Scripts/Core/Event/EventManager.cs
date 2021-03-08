using System;

namespace FunnyShooter.Core {
    public class EventManager : Singleton<EventManager> {
        private EventPool<GameEventArgs> eventPool;

        public EventManager() {
            eventPool = new EventPool<GameEventArgs>(EventPoolMode.AllowNoHandler);
        }

        public int EventHandlerCount {
            get {
                return eventPool.EventHandlerCount;
            }
        }

        public int EventCount {
            get {
                return eventPool.EventCount;
            }
        }

        public void Update() {
            eventPool.Update();
        }

        public void Shutdown() {
            eventPool.Shutdown();
        }

        public void Clear() {
            eventPool.Clear();
        }

        public int Count(int id) {
            return Count(id);
        }

        public bool Check(int id, EventHandler<GameEventArgs> handler) {
            return eventPool.Check(id, handler);
        }

        public void Subscribe(int id, EventHandler<GameEventArgs> handler) {
            eventPool.Subscribe(id, handler);
        }

        public void Unsubscribe(int id, EventHandler<GameEventArgs> handler) {
            eventPool.Unsubscribe(id, handler);
        }

        public void Fire(GameEventArgs e) {
            eventPool.Fire(e);
        }

        public void Fire(object sender, GameEventArgs e) {
            eventPool.Fire(sender, e);
        }

        public void FireNow(GameEventArgs e) {
            eventPool.FireNow(e);
        }

        public void FireNow(object sender, GameEventArgs e) {
            eventPool.FireNow(sender, e);
        }
    }
}