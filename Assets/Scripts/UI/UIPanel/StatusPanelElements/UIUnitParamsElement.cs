using UnityEngine;
using UnityEngine.UI;

public class UIUnitParamsElement : MonoBehaviour
{
    private UIUnitParamsElementTitle _elementTitle;
    private UIUnitParamsElementValue _elementValue;
    private Image _image;

    private void Awake()
    {
        _elementTitle = GetComponentInChildren<UIUnitParamsElementTitle>(true);
        _elementValue = GetComponentInChildren<UIUnitParamsElementValue>(true);
    }

    public void SetData(string title, string value, string textureName)
    {
        SetTitle(title);
        SetValue(value);
        SetImage(textureName);
    }

    private void SetTitle(string title)
    {
        _elementTitle.SetText(title);
    }

    private void SetValue(string value)
    {
        _elementValue.SetText(value);
    }

    private void SetImage(string textureName)
    {

    }
}
