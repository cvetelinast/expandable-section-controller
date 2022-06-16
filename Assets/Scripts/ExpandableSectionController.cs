using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandableSectionController : MonoBehaviour {

    [SerializeField] private Button arrow;

    [SerializeField] private CustomAnimator arrowCustomAnimator;

    [SerializeField] private List<ItemController> itemControllers;

    [SerializeField] private bool isCollapsed = false;

    private void OnEnable() {
        arrow.onClick.AddListener(OnArrowClicked);
    }

    private void OnDisable() {
        arrow.onClick.RemoveAllListeners();
    }

    private void Start() {
        if (isCollapsed) {
            RotateArrowNoAnimation();
            foreach (var c in itemControllers) {
                c.ChangeExpandOrCollapseNoAnimation(isCollapsed);
            }
        }
    }

    private void OnArrowClicked() {
        isCollapsed = !isCollapsed;
        AnimateRotateArrow();
        foreach (var c in itemControllers) {
            StartCoroutine(c.AnimateExpandOrCollapse(isCollapsed));
        }
    }

    private void AnimateRotateArrow() {
        StartCoroutine(arrowCustomAnimator.Animate(isCollapsed ? CustomAnimator.AnimationType.ROTATE_RIGHT : CustomAnimator.AnimationType.ROTATE_DOWN));
    }

    private void RotateArrowNoAnimation() {
        arrowCustomAnimator.ChangeNoAnimation(isCollapsed ? CustomAnimator.AnimationType.ROTATE_RIGHT : CustomAnimator.AnimationType.ROTATE_DOWN);
    }
}
