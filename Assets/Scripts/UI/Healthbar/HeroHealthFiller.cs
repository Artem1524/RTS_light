using UnityEngine;
using UnityEngine.UI;

public class HeroHealthFiller : Fillable
{
    private const float ANCHORED_POSITION_X = 95f; // FIX 100.2f;

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
        _fxRectTransform.localPosition = new Vector3(fxLinePositionX - ANCHORED_POSITION_X, _fxRectTransform.localPosition.y, _fxRectTransform.localPosition.z); // position è localPosition
    }
}
