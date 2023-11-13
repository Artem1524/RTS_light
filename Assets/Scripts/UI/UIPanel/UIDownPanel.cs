using UnityEngine;

public class UIDownPanel : MonoBehaviour
{
    private UIUnitPreviewPanel _unitPreviewPanel;
    private UIUnitInfoPanel _unitInfoPanel;
    private UIUnitOrdersPanel _unitOrdersPanel;

    private void Awake()
    {
        _unitPreviewPanel = GetComponentInChildren<UIUnitPreviewPanel>();
        _unitInfoPanel = GetComponentInChildren<UIUnitInfoPanel>();
        _unitOrdersPanel = GetComponentInChildren<UIUnitOrdersPanel>();
    }

    private void Start()
    {
        ResetPanelInfo();
    }

    public void UpdateUnitInfoPanel(Unit unit, UIUnitInfoData[] elementsInfo)
    {
        string unitTitle = unit.UnitType.ToString();
        UnitType unitType = unit.UnitType;
        Health unitHealth = unit.UnitHealth;

        _unitInfoPanel.UpdateUnitInfo(unitTitle, elementsInfo);
        _unitPreviewPanel.UpdateUnitPreview(unitType, unitHealth);
    }

    public void ResetPanelInfo()
    {
        _unitPreviewPanel.ResetPanelInfo();
        _unitInfoPanel.ResetPanelInfo();
        _unitOrdersPanel.ResetPanelInfo();
    }

    public void UpdateHealthInfo(Health health)
    {
        _unitPreviewPanel.UpdateUnitHealth(health);
    }
}
