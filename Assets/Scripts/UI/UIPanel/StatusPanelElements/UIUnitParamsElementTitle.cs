using TMPro;
using UnityEngine;

public class UIUnitParamsElementTitle : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        TryGetComponent(out _text);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
