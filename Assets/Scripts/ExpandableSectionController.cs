using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpandableSectionController : MonoBehaviour {

    [SerializeField] private Image background;

    [SerializeField] private Image arrowIcon;

    [SerializeField] private TextMeshProUGUI sectionTitle;

    [SerializeField] private Button arrow;

    [SerializeField] private CustomAnimator arrowCustomAnimator;

    [SerializeField] private List<ItemController> itemControllers;

    [SerializeField] private bool isCollapsed = false;

    public void ChangeBackground(Color color) {
        if (background != null) {
            background.color = color;
        }
    }

    public void ChangeSectionTitleColor(Color color) {
        if (sectionTitle != null) {
            sectionTitle.color = color;
        }
    }

    public void ChangeArrowIconColor(Color color) {
        if (arrowIcon != null) {
            arrowIcon.color = color;
        }
    }

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
