using System;
using System.Collections.Generic;

namespace FunnyShooter.Core {
    /// <summary>
    /// 引用池。
    /// </summary>
    public static partial class ReferencePool {
        private static Dictionary<Type, ReferenceCollection> referenceCollections = new Dictionary<Type, ReferenceCollection>();
        private static bool enableStrictCheck = true;

        public static bool EnableStrictCheck {
            get {
                return enableStrictCheck;
            }
            set {
                enableStrictCheck = value;
            }
        }

        public static T Acquire<T>() where T : IReference, new() {
            return GetReferenceCollection(typeof(T)).Acquire<T>();
        }

        public static IReference Acquire(Type referenceType) {
            CheckReferenceType(referenceType);
            return GetReferenceCollection(referenceType).Acquire();
        }

        public static void Release(IReference reference) {
            if (reference == null) {
                throw new CustomException("Reference type is invalid.");
            }

            Type referenceType = reference.GetType();
            CheckReferenceType(referenceType);
            GetReferenceCollection(referenceType).Release(reference);
        }

        public static void Add<T>(int count) where T : IReference, new() {
            GetReferenceCollection(typeof(T)).Add<T>(count);
        }

        public static void Add(int count, Type referenceType) {
            CheckReferenceType(referenceType);
            GetReferenceCollection(referenceType).Add(count);
        }

        public static void Remove<T>(int count) {
            GetReferenceCollection(typeof(T)).Remove(count);
        }

        public static void Remove(int count, Type referenceType) {
            CheckReferenceType(referenceType);
            GetReferenceCollection(referenceType).Remove(count);
        }

        public static void RemoveAll<T>() where T : IReference {
            GetReferenceCollection(typeof(T)).RemoveAll();
        }

        public static void RemoveAll(Type referenceType) {
            CheckReferenceType(referenceType);
            GetReferenceCollection(referenceType).RemoveAll();
        }

        public static void ClearAll() {
            lock (referenceCollections) {
                foreach (KeyValuePair<Type, ReferenceCollection> referenceCollection in referenceCollections) {
                    referenceCollection.Value.RemoveAll();
                }

                referenceCollections.Clear();
            }
        }

        private static void CheckReferenceType(Type referenceType) {
            if (!enableStrictCheck) {
                return;
            }

            if (referenceType == null) {
                throw new CustomException("Reference type is invalid.");
            }

            if (!referenceType.IsClass || referenceType.IsAbstract) {
                throw new CustomException(Utility.Text.Format("Reference type '{0}' is not non-abstract class type.", referenceType));
            }

            if (!typeof(IReference).IsAssignableFrom(referenceType)) {
                throw new CustomException(Utility.Text.Format("Reference type '{0}' is invalid.", referenceType));
            }
        }

        private static ReferenceCollection GetReferenceCollection(Type referenceType) {
            if (referenceType == null) {
                throw new CustomException("Reference type is invalid.");
            }

            ReferenceCollection referenceCollection = null;
            lock (referenceCollections) {
                if (!referenceCollections.TryGetValue(referenceType, out referenceCollection)) {
                    referenceCollection = new ReferenceCollection(referenceType);
                    referenceCollections.Add(referenceType, referenceCollection);
                }
            }

            return referenceCollection;
        }
    }
}