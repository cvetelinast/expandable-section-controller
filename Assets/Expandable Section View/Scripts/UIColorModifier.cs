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
    private Color cachedTitleColor;

    [SerializeField] private Color backgroundColor;
    private Color cachedBackgroundColor;

    // Section titles
    [SerializeField] private Color sectionTitlesColor;
    private Color cachedSectionTitlesColor;

    [SerializeField] private Color sectionTitlesBackgroundColor;
    private Color cachedSectionTitlesBackgroundColor;

    // Section items
    [SerializeField] private Color sectionItemsLabelsColor;
    private Color cachedSectionItemsLabelsColor;

    [SerializeField] private Color sectionItemsBackgroundColor;
    private Color cachedSectionItemsBackgroundColor;

    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private Image background;

    [SerializeField] private List<ExpandableSectionController> expandableSectionControllers;

    void Update() {
        if (titleColor != cachedTitleColor) {
            if (titleText != null) {
                titleText.color = titleColor;
            }
            cachedTitleColor = titleColor;
        }

        if (backgroundColor != cachedBackgroundColor) {
            if (background != null) {
                background.color = backgroundColor;
            }
            cachedBackgroundColor = backgroundColor;
        }

        if (sectionTitlesColor != cachedSectionTitlesColor) {
            foreach (var e in expandableSectionControllers) {
                if (e != null) {
                    e.ChangeSectionTitleColor(sectionTitlesColor);
                    e.ChangeArrowIconColor(sectionTitlesColor);
                }
            }
            cachedSectionTitlesColor = sectionTitlesColor;
        }

        if (sectionTitlesBackgroundColor != cachedSectionTitlesBackgroundColor ||
            sectionItemsBackgroundColor != cachedSectionItemsBackgroundColor ||
            sectionItemsLabelsColor != cachedSectionItemsLabelsColor) {

            foreach (var e in expandableSectionControllers) {
                if (e != null) {
                    e.ChangeBackground(sectionTitlesBackgroundColor);
                    e.ChangeItemColors(sectionItemsBackgroundColor, sectionItemsLabelsColor);
                }
            }
            cachedSectionTitlesBackgroundColor = sectionTitlesBackgroundColor;
            cachedSectionItemsBackgroundColor = sectionItemsBackgroundColor;
            cachedSectionItemsLabelsColor = sectionItemsLabelsColor;

        }
    }
}
