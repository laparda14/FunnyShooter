using UnityEngine;

public static class GameObjectEx {
    public static void SetActiveSafe(this GameObject gameObject, bool value) {
        if(gameObject.activeSelf != value) {
            gameObject.SetActive(value);
        }
    }
}