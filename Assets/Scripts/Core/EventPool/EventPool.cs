using System;
using System.Collections.Generic;

namespace FunnyShooter.Core {
    /// <summary>
    /// 事件池。
    /// </summary>
    /// <typeparam name="T">事件类型。</typeparam>
    public sealed partial class EventPool<T> where T : BaseEventArgs {
        private readonly CustomMultiDictionary<int, EventHandler<T>> eventHandlers;
        private readonly Queue<Event> events;
        private readonly EventPoolMode eventPoolMode;

        public EventPool(EventPoolMode mode) {
            eventHandlers = new CustomMultiDictionary<int, EventHandler<T>>();
            events = new Queue<Event>();
            eventPoolMode = mode;
        }

        public int EventHandlerCount {
            get {
                return eventHandlers.Count;
            }
        }

        public int EventCount {
            get {
                return events.Count;
            }
        }

        public void Update() {
            while (events.Count != 0) {
                Event eventNode = null;
                lock (events) {
                    eventNode = events.Dequeue();
                    HandleEvent(eventNode.Sender, eventNode.EventArgs);
                }

                ReferencePool.Release(eventNode);
            }
        }

        public void Shutdown() {
            Clear();
            eventHandlers.Clear();
        }

        public void Clear() {
            events.Clear();
        }

        public int Count(int id) {
            if (eventHandlers.TryGetValue(id, out CustomLinkedListRange<EventHandler<T>> range)) {
                return range.Count;
            }

            return 0;
        }

        public bool Check(int id, EventHandler<T> handler) {
            if (handler == null) {
                throw new CustomException(Utility.Text.Format("Event '{0}' handler is invalid.", id));
            }

            return eventHandlers.Contains(id, handler);
        }


        public void Subscribe(int id, EventHandler<T> handler) {
            if (handler == null) {
                throw new CustomException(Utility.Text.Format("Event '{0}' handler is invalid.", id));
            }

            if (!eventHandlers.Contains(id, handler)) {
                eventHandlers.Add(id, handler);
            } else if ((eventPoolMode & EventPoolMode.AllowMultiHandler) != EventPoolMode.AllowMultiHandler) {
                throw new CustomException(Utility.Text.Format("Event '{0}' handler not allow mulit invalid.", id));
            } else if ((eventPoolMode & EventPoolMode.AllDuplicateHandler) != EventPoolMode.AllDuplicateHandler) {
                throw new CustomException(Utility.Text.Format("Event '{0}' handler not allow duplicate invalid.", id));
            } else {
                eventHandlers.Add(id, handler);
            }
        }

        public void Unsubscribe(int id, EventHandler<T> handler) {
            if (handler == null) {
                throw new CustomException(Utility.Text.Format("Event '{0}' handler is invalid.", id));
            }

            if (!eventHandlers.Remove(id, handler)) {
                throw new CustomException(Utility.Text.Format("Event '{0}' not exist specified handler.", id));
            }
        }

        public void Fire(T e) {
            Fire(null, e);
        }

        public void Fire(object sender, T e) {
            if (e == null) {
                throw new CustomException("Event is invalid.");
            }

            lock (events) {
                Event eventNode = Event.Creat(sender, e);
                events.Enqueue(eventNode);
            }
        }

        public void FireNow(T e) {
            FireNow(null, e);
        }

        public void FireNow(object sender, T e) {
            if (e == null) {
                throw new CustomException("Event is invalid.");
            }

            HandleEvent(sender, e);
        }

        private void HandleEvent(object sender, T e) {
            bool noHandlerException = false;
            if (eventHandlers.TryGetValue(e.Id, out CustomLinkedListRange<EventHandler<T>> range)) {
                foreach (EventHandler<T> handler in range) {
                    handler(sender, e);
                }
            } else if ((eventPoolMode & EventPoolMode.AllowNoHandler) != EventPoolMode.AllowNoHandler) {
                noHandlerException = true;
            }

            ReferencePool.Release(e);

            if (noHandlerException) {
                throw new CustomException("Event not allow on handler.");
            }
        }
    }
}