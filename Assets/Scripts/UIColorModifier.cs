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

    [SerializeField] private List<ItemController> itemControllers;

    void Update() {
        if (titleText != null) {
            titleText.color = titleColor;
        }

        if (background != null) {
            background.color = backgroundColor;
        }

        for (int i = 0; i < expandableSectionControllers.Count; i++) {
            if (expandableSectionControllers[i] != null) {
                expandableSectionControllers[i].ChangeSectionTitleColor(sectionTitlesColor);
                expandableSectionControllers[i].ChangeArrowIconColor(sectionTitlesColor);
                expandableSectionControllers[i].ChangeBackground(sectionTitlesBackgroundColor);
            }
        }

        for (int i = 0; i < itemControllers.Count; i++) {
            if (itemControllers[i] != null) {
                itemControllers[i].ChangeBackground(sectionItemsBackgroundColor);
                itemControllers[i].ChangeLabelColor(sectionItemsLabelsColor);
                itemControllers[i].ChangeIconColor(sectionItemsLabelsColor);
            }
        }
    }
}
