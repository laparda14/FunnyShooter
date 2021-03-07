using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FunnyShooter.Core {
    /// <summary>
    /// 多值字典类
    /// </summary>
    /// <typeparam name="TKey">多值字典的主键类型</typeparam>
    /// <typeparam name="TValue">多值字典的值类型</typeparam>
    public sealed class CustomMultiDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, CustomLinkedListRange<TValue>>>, IEnumerable {
        private readonly CustomLinkedList<TValue> linkedList;
        private readonly Dictionary<TKey, CustomLinkedListRange<TValue>> dictionary;

        public CustomMultiDictionary() {
            linkedList = new CustomLinkedList<TValue>();
            dictionary = new Dictionary<TKey, CustomLinkedListRange<TValue>>();
        }

        public CustomLinkedListRange<TValue> this[TKey key] {
            get {
                dictionary.TryGetValue(key, out CustomLinkedListRange<TValue> range);
                return range;
            }
        }

        public int Count {
            get {
                return dictionary.Count;
            }
        }

        public void Add(TKey key, TValue value) {
            if (dictionary.TryGetValue(key, out CustomLinkedListRange<TValue> range)) {
                linkedList.AddBefore(range.End, value);
            } else {
                LinkedListNode<TValue> start = linkedList.AddLast(value);
                LinkedListNode<TValue> end = linkedList.AddLast(default(TValue));
                range = new CustomLinkedListRange<TValue>(start, end);
                dictionary.Add(key, range);
            }
        }

        public bool Remove(TKey key, TValue value) {
            if (dictionary.TryGetValue(key, out CustomLinkedListRange<TValue> range)) {
                for (LinkedListNode<TValue> current = range.Start; current != null && current != range.End; current = current.Next) {
                    if (current.Value.Equals(value)) {
                        if (current == range.Start) {
                            LinkedListNode<TValue> next = current.Next;
                            if (next == range.End) {
                                linkedList.Remove(next);
                                dictionary.Remove(key);
                            } else {
                                dictionary[key] = new CustomLinkedListRange<TValue>(next, range.End);
                            }
                        }

                        linkedList.Remove(value);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool RemoveAll(TKey key) {
            if (dictionary.TryGetValue(key, out CustomLinkedListRange<TValue> range)) {
                for (LinkedListNode<TValue> current = range.Start; current != null; current = current.Next) {
                    linkedList.Remove(current);
                }

                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        public void Clear() {
            dictionary.Clear();
            linkedList.Clear();
        }

        public bool Contains(TKey key) {
            return dictionary.ContainsKey(key);
        }

        public bool Contains(TKey key, TValue value) {
            if (dictionary.TryGetValue(key, out CustomLinkedListRange<TValue> range)) {
                return range.Contains(value);
            }

            return false;
        }

        public bool TryGetValue(TKey key, out CustomLinkedListRange<TValue> range) {
            return dictionary.TryGetValue(key, out range);
        }

        public Enumerator GetEnumerator() {
            return new Enumerator(dictionary);
        }

        IEnumerator<KeyValuePair<TKey, CustomLinkedListRange<TValue>>> IEnumerable<KeyValuePair<TKey, CustomLinkedListRange<TValue>>>.GetEnumerator() {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, CustomLinkedListRange<TValue>>>, IEnumerator {
            private Dictionary<TKey, CustomLinkedListRange<TValue>>.Enumerator enumerator;

            public Enumerator(Dictionary<TKey, CustomLinkedListRange<TValue>> dictionary) {
                if (dictionary == null) {
                    throw new CustomException("Dictionary is invalid.");
                }

                enumerator = dictionary.GetEnumerator();
            }

            public KeyValuePair<TKey, CustomLinkedListRange<TValue>> Current {
                get {
                    return enumerator.Current;
                }
            }

            object IEnumerator.Current {
                get {
                    return enumerator.Current;
                }
            }

            public void Dispose() {
                enumerator.Dispose();
            }

            public bool MoveNext() {
                return enumerator.MoveNext();
            }

            public void Reset() {
                ((IEnumerator)enumerator).Reset();
            }
        }
    }
}