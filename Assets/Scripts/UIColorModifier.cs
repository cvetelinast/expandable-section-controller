using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class UIColorModifier : MonoBehaviour {

    // Background
    [SerializeField] private Color titleColor;
    [SerializeField] private Color backgroundColor;

    // Section titles
    [SerializeField] private Color sectionTitlesColor;
    [SerializeField] private Color sectionTitlesBackgroundColor;

    // Section items
    [SerializeField] private Color sectionItemsLabelsColor;
    [SerializeField] private Color sectionItemsBackgroundColor;

    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private Image background;

    [SerializeField] private List<ExpandableSectionController> expandableSectionControllers;

    void Update() {
        if (titleText != null) {
            titleText.color = titleColor;
        }

        if (background != null) {
            background.color = backgroundColor;
        }

        foreach (var e in expandableSectionControllers) {
            if (e != null) {
                e.ChangeSectionTitleColor(sectionTitlesColor);
                e.ChangeArrowIconColor(sectionTitlesColor);
                e.ChangeBackground(sectionTitlesBackgroundColor);
                e.ChangeItemColors(sectionItemsBackgroundColor, sectionItemsLabelsColor);
            }
        }

    }
}
