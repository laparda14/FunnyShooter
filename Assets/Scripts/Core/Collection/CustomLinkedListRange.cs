using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FunnyShooter.Core {
    /// <summary>
    /// 链表范围结构体
    /// 只存储起始节点和结束节点。
    /// </summary>
    /// <typeparam name="T">链表范围的元素类型</typeparam>
    [StructLayout(LayoutKind.Auto)]
    public struct CustomLinkedListRange<T> : IEnumerable<T>, IEnumerable {
        private LinkedListNode<T> start;
        private LinkedListNode<T> end;

        public CustomLinkedListRange(LinkedListNode<T> start, LinkedListNode<T> end) {
            this.start = start;
            this.end = end;
        }

        public bool IsValid {
            get {
                return start != null && end != null && start != end;
            }
        }

        public LinkedListNode<T> Start {
            get {
                return start;
            }
        }

        public LinkedListNode<T> End {
            get {
                return end;
            }
        }

        public int Count {
            get {
                if (!IsValid) {
                    return 0;
                }

                int count = 0;
                for (LinkedListNode<T> current = start; current != null && current != end; current = current.Next) {
                    count++;
                }

                return count;
            }
        }

        public bool Contains(T value) {
            for (LinkedListNode<T> current = start; current != null && current != end; current = current.Next) {
                if (current.Value.Equals(value)) {
                    return true;
                }
            }

            return false;
        }


        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator : IEnumerator<T>, IEnumerator {
            private readonly CustomLinkedListRange<T> CustomLinkedListRange;
            private LinkedListNode<T> currentNode;
            private T currentValue;

            public Enumerator(CustomLinkedListRange<T> range) {
                if (!range.IsValid) {
                    throw new CustomException("Range is invalid.");
                }

                CustomLinkedListRange = range;
                currentNode = CustomLinkedListRange.Start;
                currentValue = default(T);
            }

            public T Current {
                get {
                    return currentValue;
                }
            }

            object IEnumerator.Current {
                get {
                    return currentValue;
                }
            }

            public void Dispose() {
            }

            public bool MoveNext() {
                if (currentNode == null || currentNode == CustomLinkedListRange.End) {
                    return false;
                }

                currentValue = currentNode.Value;
                currentNode = currentNode.Next;
                return true;
            }

            void IEnumerator.Reset() {
                currentNode = CustomLinkedListRange.Start;
                currentValue = default(T);
            }
        }
    }
}