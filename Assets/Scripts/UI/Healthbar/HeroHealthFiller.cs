using UnityEngine;
using UnityEngine.UI;

public class HeroHealthFiller : Fillable
{
    private const float SHIFT = 4f; // Magnitude FIX 100.2f; 2f -> Picture Shift

    [SerializeField]
    private Image _healthBar;
    [SerializeField]
    private FXLine _fxLine;

    private Canvas _canvas;
    private Rect _healthBarRect;
    private RectTransform _fxRectTransform;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        _healthBarRect = RectTransformUtility.PixelAdjustRect(_healthBar.GetComponent<RectTransform>(), _canvas);
        _fxRectTransform = _fxLine.GetComponent<RectTransform>();
    }

    public override void SetFillValue(float fillAmount)
    {
        _healthBar.fillAmount = fillAmount;
        float fxLinePositionX = _healthBarRect.width * fillAmount;
        float anchoredPositionShift = _fxRectTransform.anchoredPosition.x - _fxRectTransform.localPosition.x;
        _fxRectTransform.localPosition = new Vector3(fxLinePositionX - (anchoredPositionShift + SHIFT), _fxRectTransform.localPosition.y, _fxRectTransform.localPosition.z); // position � localPosition
    }
}
