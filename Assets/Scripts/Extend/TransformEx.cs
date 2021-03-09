using UnityEngine;

public static class TransformEx {
    public static void LocalReset(this Transform transform) {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}