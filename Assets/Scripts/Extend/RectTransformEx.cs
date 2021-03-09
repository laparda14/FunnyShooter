using UnityEngine;

public static class RectTransformEx {
    public static void StretchToFullScreen(this RectTransform rectTransform) {
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}