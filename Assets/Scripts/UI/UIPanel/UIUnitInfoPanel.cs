using System;
using UnityEngine;

public class UIUnitInfoPanel : MonoBehaviour
{
    private UIUnitTitle _unitTitle;
    private UIUnitParamsElement[] _unitParamElements;

    public static uint UnitParamElementsCount { get; private set; } = 4;

    private void Awake()
    {
        _unitTitle = GetComponentInChildren<UIUnitTitle>();
        _unitParamElements = GetComponentsInChildren<UIUnitParamsElement>(true);

        UnitParamElementsCount = (uint) _unitParamElements.Length;
    }

    public void UpdateUnitInfo(string unitTitle, UIUnitInfoData[] elementsInfo)
    {
        UpdateUnitTitle(unitTitle);
        UpdateUnitParameters(elementsInfo);
    }

    private void UpdateUnitTitle(string unitTitle)
    {
        _unitTitle.SetText(unitTitle);
    }

    private void UpdateUnitParameters(UIUnitInfoData[] elementsInfo)
    {
        ResetParamsElements();

        for (int i = 0; i < elementsInfo.Length && i < _unitParamElements.Length; i++)
        {
            UIUnitInfoData data = elementsInfo[i];
            _unitParamElements[i].SetData(data.ParamTitle, data.ParamValue, data.ParamTextureName);
            _unitParamElements[i].gameObject.SetActive(true);
        }
    }

    public void ResetPanelInfo()
    {
        ResetTitle();
        ResetParamsElements();
    }

    private void ResetTitle()
    {
        _unitTitle.SetText("");
    }

    private void ResetParamsElements()
    {
        foreach (UIUnitParamsElement element in _unitParamElements)
            element.gameObject.SetActive(false);
    }
}
