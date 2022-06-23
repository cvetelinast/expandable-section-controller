using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour {

    [SerializeField] private CustomAnimator customAnimator;

    [SerializeField] private Image icon;

    [SerializeField] private Image background;

    [SerializeField] private TextMeshProUGUI itemLabel;

    public IEnumerator AnimateExpandOrCollapse(bool newIsCollapsed) =>
        customAnimator.Animate(newIsCollapsed ? CustomAnimator.AnimationType.COLLAPSE_AND_FADE_OUT : CustomAnimator.AnimationType.EXPAND_AND_FADE_IN);

    public void ChangeExpandOrCollapseNoAnimation(bool newIsCollapsed) =>
        customAnimator.ChangeNoAnimation(newIsCollapsed ? CustomAnimator.AnimationType.COLLAPSE_AND_FADE_OUT : CustomAnimator.AnimationType.EXPAND_AND_FADE_IN);

    public void ChangeIconColor(Color color) {
        if (icon != null) {
            icon.color = color;
        }
    }

    public void ChangeBackground(Color color) {
        if (background != null) {
            background.color = color;
        }
    }

    public void ChangeLabelColor(Color color) {
        if (itemLabel != null) {
            itemLabel.color = color;
        }
    }
}
