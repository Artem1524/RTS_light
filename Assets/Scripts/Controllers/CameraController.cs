using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraController : MonoBehaviour
{
    private const string UNIT_TAG = "Unit";
    private const string ATTACK_TEXTURE_NAME = "Attack";
    private const string ARMOR_TEXTURE_NAME = "Armor";

    private const string ATTACK_PARAM_TITLE = "Атака:";
    private const string ARMOR_PARAM_TITLE = "Защита:";

    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private UIDownPanel _uiDownPanel;
    [SerializeField]
    private SelectionCircle _selectionCircle;
    [SerializeField]
    private Transform _selectionCircleObjectPool;

    private CameraControls _controls;

    private Unit _selectedUnit;

    private void Awake()
    {
        _controls = new CameraControls();
        _controls.Enable();

        _controls.Player.LeftClick.performed += OnLeftClick;
    }

    private void OnLeftClick(CallbackContext context)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition); // ���������� �� new InputSystem

        if (!Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            ResetUnitSelection();
            return;
        }

        Collider collider = raycastHit.collider;

        if (collider == null)
        {
            ResetUnitSelection();
            return;
        }

        string tag = collider.gameObject.tag;

        if (tag == UNIT_TAG)
        {
            ResetUnitSelection();

            Unit unit = collider.transform.parent.GetComponent<Unit>();
            _selectedUnit = unit;
            UpdateUIUnitInfo(unit);
            SubscribeUnitHealthChanged(unit);
            MakeUnitSelection(unit.SelectionCirclePoint);
        }
        else
        {
            ResetUnitSelection();
        }
    }

    private void UpdateUIUnitInfo(Unit unit)
    {
        UIUnitInfoData[] paramsInfo = GetUnitParamsInfo(unit);
        _uiDownPanel.UpdateUnitInfoPanel(unit, paramsInfo);
    }

    private UIUnitInfoData[] GetUnitParamsInfo(Unit unit)
    {
        List<UIUnitInfoData> unitParamsData = new List<UIUnitInfoData>();

        if (UIUnitInfoPanel.UnitParamElementsCount < 2) // ������� ����� ������ ��������
            return unitParamsData.ToArray();

        if (unit.UnitParams.UnitBattleParams.Attack > 0)
        {
            unitParamsData.Add(MakeUnitInfoData(ATTACK_TEXTURE_NAME, ATTACK_PARAM_TITLE, unit.UnitParams.UnitBattleParams.Attack.ToString()));
        }

        // unitParamsData.Add(MakeUnitInfoData(ARMOR_TEXTURE_NAME, ARMOR_PARAM_TITLE, unit.UnitParams.UnitBaseParams.Armor.ToString())); ������ textureName

        return unitParamsData.ToArray();
    }

    private void ResetUnitSelection()
    {
        _selectionCircle.transform.parent = _selectionCircleObjectPool;
        _selectionCircle.transform.localPosition = Vector3.zero;
        _selectionCircle.gameObject.SetActive(false);

        ResetSelectedUnitSubscriptions();
        ResetUIUnitInfo();
    }

    private void MakeUnitSelection(SelectionCirclePoint selectionPoint)
    {
        _selectionCircle.transform.parent = selectionPoint.transform;
        _selectionCircle.transform.localPosition = Vector3.zero;
        _selectionCircle.gameObject.SetActive(true);
    }

    private void ResetUIUnitInfo()
    {
        _uiDownPanel.ResetPanelInfo();
    }

    private UIUnitInfoData MakeUnitInfoData(string textureName, string paramTitle, string paramValue)
    {
        return new UIUnitInfoData(textureName, paramTitle, paramValue);
    }

    private void ResetSelectedUnitSubscriptions()
    {
        if (_selectedUnit != null) // _selectedUnit == null
        {
            UnsubscribeUnitHealthChanged(_selectedUnit);
            _selectedUnit = null;
        }
    }

    private void SubscribeUnitHealthChanged(Unit unit)
    {
        unit.UnitHealth.OnHealthChanged += OnHealthChanged;
    }

    public void SubscribeOnDieEvent(Unit unit)
    {
        unit.OnDie += CancelSelectionOnDieUnit;
    }

    private void UnsubscribeUnitHealthChanged(Unit unit)
    {
        unit.UnitHealth.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(Health health)
    {
        _uiDownPanel.UpdateHealthInfo(health);
    }

    private void CancelSelectionOnDieUnit(Unit unit)
    {
        if (_selectionCircle.transform.parent == unit.SelectionCirclePoint)
            //
            ResetUnitSelection();
    }
}