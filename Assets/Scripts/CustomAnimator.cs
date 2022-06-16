using System.Collections;
using UnityEngine;

public class CustomAnimator : MonoBehaviour {

    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private float duration = 0.25f;

    private const float ALPHA_VISIBLE = 1f;
    private const float ALPHA_INVISIBLE = 0f;
    private const float COLLAPSED_SIZE = 0f;

    private Quaternion ROTATION_RIGHT = Quaternion.AngleAxis(90, Vector3.forward);
    private Quaternion ROTATION_DOWN = Quaternion.identity;

    private float expandedSize;

    public enum AnimationType {
        COLLAPSE,
        EXPAND,
        COLLAPSE_AND_FADE_OUT,
        EXPAND_AND_FADE_IN,
        ROTATE_DOWN,
        ROTATE_RIGHT
    }

    public IEnumerator Animate(AnimationType animationType) =>
        animationType switch {
            AnimationType.COLLAPSE => AnimateSize(expandedSize, COLLAPSED_SIZE),
            AnimationType.EXPAND => AnimateSize(COLLAPSED_SIZE, expandedSize),
            AnimationType.COLLAPSE_AND_FADE_OUT => AnimateAlphaAndSize(ALPHA_VISIBLE, ALPHA_INVISIBLE, expandedSize, COLLAPSED_SIZE),
            AnimationType.EXPAND_AND_FADE_IN => AnimateAlphaAndSize(ALPHA_INVISIBLE, ALPHA_VISIBLE, COLLAPSED_SIZE, expandedSize),
            AnimationType.ROTATE_DOWN => AnimateRotation(ROTATION_RIGHT, ROTATION_DOWN),
            AnimationType.ROTATE_RIGHT => AnimateRotation(ROTATION_DOWN, ROTATION_RIGHT),
            _ => throw new System.NotImplementedException(),
        };

    public void ChangeNoAnimation(AnimationType animationType) {
        switch (animationType) {
            case AnimationType.COLLAPSE:
                ChangeSize(COLLAPSED_SIZE);
                break;
            case AnimationType.EXPAND:
                ChangeSize(expandedSize);
                break;
            case AnimationType.COLLAPSE_AND_FADE_OUT:
                ChangeAlphaAndSize(ALPHA_INVISIBLE, COLLAPSED_SIZE);
                break;
            case AnimationType.EXPAND_AND_FADE_IN:
                ChangeAlphaAndSize(ALPHA_VISIBLE, expandedSize);
                break;
            case AnimationType.ROTATE_DOWN:
                ChangeRotation(ROTATION_DOWN);
                break;
            case AnimationType.ROTATE_RIGHT:
                ChangeRotation(ROTATION_RIGHT);
                break;
            default:
                throw new System.NotImplementedException();
        }
    }

    private IEnumerator AnimateAlphaAndSize(float startAlpha, float endAlpha, float startSizeDeltaY, float endSizeDeltaY) {
        float time = 0;
        Vector2 sizeDelta = rectTransform.sizeDelta;
        while (time < duration) {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            sizeDelta.y = Mathf.Lerp(startSizeDeltaY, endSizeDeltaY, time / duration);
            rectTransform.sizeDelta = sizeDelta;
            time += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        sizeDelta.y = endSizeDeltaY;
        rectTransform.sizeDelta = sizeDelta;
    }

    private void ChangeAlphaAndSize(float endAlpha, float endSizeDeltaY) {
        canvasGroup.alpha = endAlpha;

        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.y = endSizeDeltaY;
        rectTransform.sizeDelta = sizeDelta;
    }

    private IEnumerator AnimateSize(float startSizeDeltaY, float endSizeDeltaY) {
        float time = 0;
        Vector2 sizeDelta = rectTransform.sizeDelta;
        while (time < duration) {
            sizeDelta.y = Mathf.Lerp(startSizeDeltaY, endSizeDeltaY, time / duration);
            rectTransform.sizeDelta = sizeDelta;
            time += Time.deltaTime;
            yield return null;
        }

        sizeDelta.y = endSizeDeltaY;
        rectTransform.sizeDelta = sizeDelta;
    }

    private void ChangeSize(float endSizeDeltaY) {
        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.y = endSizeDeltaY;
        rectTransform.sizeDelta = sizeDelta;
    }

    private IEnumerator AnimateRotation(Quaternion startRotation, Quaternion endRotation) {
        float time = 0;
        while (time < duration) {
            rectTransform.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        rectTransform.rotation = endRotation;
    }

    private void ChangeRotation(Quaternion endRotation) {
        rectTransform.rotation = endRotation;
    }

    // Start is called before the first frame update
    void Start() {
        expandedSize = rectTransform.rect.height;
    }
}
