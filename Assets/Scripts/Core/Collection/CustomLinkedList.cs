using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FunnyShooter.Core {
    /// <summary>
    /// 游戏框架链表类
    /// 对比：多了缓存操作
    /// </summary>
    /// <typeparam name="T">链表的元素类型。</typeparam>
    public sealed class CustomLinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable {
        private LinkedList<T> linkedList;
        private Queue<LinkedListNode<T>> cachedNodes;

        public CustomLinkedList() {
            linkedList = new LinkedList<T>();
            cachedNodes = new Queue<LinkedListNode<T>>();
        }

        public int Count {
            get {
                return linkedList.Count;
            }
        }

        public LinkedListNode<T> First {
            get {
                return linkedList.First;
            }
        }

        public LinkedListNode<T> Last {
            get {
                return linkedList.Last;
            }
        }

        bool ICollection<T>.IsReadOnly {
            get {
                return ((ICollection<T>)linkedList).IsReadOnly;
            }
        }

        object ICollection.SyncRoot {
            get {
                return ((ICollection)linkedList).SyncRoot;
            }
        }

        bool ICollection.IsSynchronized {
            get {
                return ((ICollection)linkedList).IsSynchronized;
            }
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value) {
            LinkedListNode<T> newNode = AcquireNode(value);
            linkedList.AddAfter(node, newNode);
            return newNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode) {
            linkedList.AddAfter(node, newNode);
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value) {
            LinkedListNode<T> newNode = AcquireNode(value);
            linkedList.AddBefore(node, newNode);
            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode) {
            linkedList.AddBefore(node, newNode);
        }

        public LinkedListNode<T> AddFirst(T value) {
            LinkedListNode<T> newNode = AcquireNode(value);
            linkedList.AddFirst(newNode);
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> node) {
            linkedList.AddFirst(node);
        }

        public LinkedListNode<T> AddLast(T value) {
            LinkedListNode<T> newNode = AcquireNode(value);
            linkedList.AddLast(newNode);
            return newNode;
        }

        public void AddLast(LinkedListNode<T> node) {
            linkedList.AddLast(node);
        }

        public void Clear() {
            LinkedListNode<T> current = linkedList.First;
            while (current != null) {
                ReleaseNode(current);
                current = current.Next;
            }

            linkedList.Clear();
        }

        public void ClearCachedNodes() {
            cachedNodes.Clear();
        }

        public bool Contains(T value) {
            return linkedList.Contains(value);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            linkedList.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index) {
            ((ICollection)linkedList).CopyTo(array, index);
        }

        public void Find(T value) {
            linkedList.Find(value);
        }

        public void FindLast(T value) {
            linkedList.FindLast(value);
        }

        public bool Remove(T value) {
            LinkedListNode<T> node = linkedList.Find(value);
            if (node != null) {
                linkedList.Remove(value);
                ReleaseNode(node);
                return true;
            }

            return false;
        }

        public void Remove(LinkedListNode<T> node) {
            linkedList.Remove(node);
            ReleaseNode(node);
        }

        public void RemoveFirst() {
            LinkedListNode<T> first = linkedList.First;
            if (first == null) {
                throw new CustomException("First is invalid.");
            }

            linkedList.RemoveFirst();
            ReleaseNode(first);
        }

        public void RemoveLast() {
            LinkedListNode<T> last = linkedList.Last;
            if (last == null) {
                throw new CustomException("Last is invalid.");
            }

            linkedList.RemoveLast();
            ReleaseNode(last);
        }

        public Enumerator GetEnumerator() {
            return new Enumerator(linkedList);
        }

        private LinkedListNode<T> AcquireNode(T value) {
            LinkedListNode<T> node = null;
            if (cachedNodes.Count > 0) {
                node = cachedNodes.Dequeue();
                node.Value = value;
            } else {
                node = new LinkedListNode<T>(value);
            }

            return node;
        }

        private void ReleaseNode(LinkedListNode<T> node) {
            node.Value = default(T);
            cachedNodes.Enqueue(node);
        }

        void ICollection<T>.Add(T value) {
            AddLast(value);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator : IEnumerator<T>, IEnumerator {
            private LinkedList<T>.Enumerator enumerator;

            public Enumerator(LinkedList<T> linkedList) {
                if (linkedList == null) {
                    throw new CustomException("Linked list is invalid.");
                }

                enumerator = linkedList.GetEnumerator();
            }

            public T Current {
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

            void IEnumerator.Reset() {
                ((IEnumerator<T>)enumerator).Reset();
            }
        }
    }
}