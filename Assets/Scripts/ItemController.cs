using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour {

    [SerializeField] private CustomAnimator customAnimator;

    public IEnumerator AnimateExpandOrCollapse(bool newIsCollapsed) =>
        customAnimator.Animate(newIsCollapsed ? CustomAnimator.AnimationType.COLLAPSE_AND_FADE_OUT : CustomAnimator.AnimationType.EXPAND_AND_FADE_IN);

    public void ChangeExpandOrCollapseNoAnimation(bool newIsCollapsed) =>
        customAnimator.ChangeNoAnimation(newIsCollapsed ? CustomAnimator.AnimationType.COLLAPSE_AND_FADE_OUT : CustomAnimator.AnimationType.EXPAND_AND_FADE_IN);
}
