using System;
using System.Collections.Generic;

namespace FunnyShooter.Core {
    public static partial class ReferencePool {
        private sealed class ReferenceCollection {
            private readonly Queue<IReference> references;
            private readonly Type referenceType;

            public ReferenceCollection(Type referenceType) {
                references = new Queue<IReference>();
                this.referenceType = referenceType;
            }

            public T Acquire<T>() where T : IReference, new() {
                if (typeof(T) != referenceType) {
                    throw new CustomException(Utility.Text.Format("Type '{0}' is diffence from '{1}'.", typeof(T), references));
                }

                if (references.Count > 0) {
                    lock (references) {
                        return (T)references.Dequeue();
                    }
                }

                return new T();
            }

            public IReference Acquire() {
                if (references.Count > 0) {
                    lock (references) {
                        return references.Dequeue();
                    }
                } else {
                    return (IReference)Activator.CreateInstance(referenceType);
                }
            }

            public void Release(IReference reference) {
                reference.Clear();
                lock (references) {
                    if (enableStrictCheck && references.Contains(reference)) {
                        throw new CustomException(Utility.Text.Format("Reference '{0}' is exist in references.", reference));
                    }

                    references.Enqueue(reference);
                }
            }

            public void Add<T>(int count) where T : IReference, new() {
                if (typeof(T) != referenceType) {
                    throw new CustomException(Utility.Text.Format("Type '{0}' is diffence from '{1}'.", typeof(T), references));
                }

                lock (references) {
                    while (count-- > 0) {
                        references.Enqueue(new T());
                    }
                }
            }

            public void Add(int count) {
                lock (references) {
                    while (count-- > 0) {
                        references.Enqueue((IReference)Activator.CreateInstance(referenceType));
                    }
                }
            }

            public void Remove(int count) {
                lock (references) {
                    while (count-- > 0 && references.Count > 0) {
                        references.Dequeue();
                    }
                }
            }

            public void RemoveAll() {
                lock (references) {
                    references.Clear();
                }
            }
        }
    }
}
