using TMPro;
using UnityEngine;

public class UIUnitHealth : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
