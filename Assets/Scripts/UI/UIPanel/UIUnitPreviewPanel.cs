using UnityEngine;
using UnityEngine.UI;

public class UIUnitPreviewPanel : MonoBehaviour
{
    private UIUnitHealth _uiUnitHealth;
    private RawImage _unitPreview;

    private void Awake()
    {
        _uiUnitHealth = GetComponentInChildren<UIUnitHealth>();
        _unitPreview = GetComponentInChildren<RawImage>();
    }

    public void UpdateUnitPreview(UnitType unitType, Health unitHealth)
    {
        UpdateUnitPreviewModel(unitType);
        ActivateAndUpdateHealthInfo(unitHealth);
    }

    public void ResetPanelInfo()
    {
        ResetUnitPreviewModel();
        ResetUnitHealth();
    }

    public void UpdateUnitHealth(Health unitHealth)
    {
        _uiUnitHealth.SetText(MakeHealthText(unitHealth));
    }

    private void ActivateAndUpdateHealthInfo(Health unitHealth)
    {
        UpdateUnitHealth(unitHealth);
        _uiUnitHealth.gameObject.SetActive(true);
    }

    private void ResetUnitHealth()
    {
        _uiUnitHealth.gameObject.SetActive(false);
        _uiUnitHealth.SetText("");
    }

    private void UpdateUnitPreviewModel(UnitType unitType)
    {
        // ������ Preview ������
        _unitPreview.gameObject.SetActive(true);
    }

    private void ResetUnitPreviewModel()
    {
        _unitPreview.gameObject.SetActive(false);
        // ������� Preview ������
    }

    private string MakeHealthText(Health unitHealth)
    {
        return $"{unitHealth.CurrentHealth:f0} / {unitHealth.MaxHealth:f0}";
    }
}
