namespace FunnyShooter.Core {
    public partial class EventPool<T> where T : BaseEventArgs {
        /// <summary>
        /// 事件节点。
        /// </summary>
        private sealed class Event : IReference {
            private object sender;
            private T eventArgs;

            public Event() {
                sender = null;
                eventArgs = null;
            }

            public object Sender {
                get {
                    return sender;
                }
            }

            public T EventArgs {
                get {
                    return eventArgs;
                }
            }

            public static Event Creat(object sender, T e) {
                Event eventNode = ReferencePool.Acquire<Event>();
                eventNode.sender = sender;
                eventNode.eventArgs = e;
                return eventNode;
            }

            public void Clear() {
                sender = null;
                eventArgs = null;
            }
        }
    }
}