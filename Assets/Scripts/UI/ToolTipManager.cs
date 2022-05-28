using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tooltiptext;
    [SerializeField] RectTransform tipWindowRectTransform;

    public static Action<string, Vector2> onMouseHover;
    public static Action onMouseNotHover;

    void OnEnable()
    {
        onMouseHover += DisplayToolTip;
        onMouseNotHover += HideToolTip;
    }

    private void OnDisable()
    {
        onMouseHover -= DisplayToolTip;
        onMouseNotHover -= HideToolTip;
    }

    private void Start()
    {
        HideToolTip();
    }
    void DisplayToolTip(string toolTip, Vector2 cursorPos)
    {
        tooltiptext.text = toolTip;

        tipWindowRectTransform.sizeDelta = new Vector2(
                tooltiptext.preferredWidth > 250 ? 250 : tooltiptext.preferredWidth, tooltiptext.preferredHeight);
        
        tipWindowRectTransform.gameObject.SetActive(true);

        tipWindowRectTransform.transform.position = new Vector2(
            cursorPos.x + 25, 150);
    }

    void HideToolTip()
    {
        tooltiptext.text = default;
        tipWindowRectTransform.gameObject.SetActive(false);
    }
}
