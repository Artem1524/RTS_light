using UnityEngine;
using UnityEngine.UI;

public class UnitHealthFiller : Fillable
{
    [SerializeField]
    private Image _healthBar;
    public override void SetFillValue(float fillAmount)
    {
        _healthBar.fillAmount = fillAmount;
    }
}
