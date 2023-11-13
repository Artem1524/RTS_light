using System.Collections.Generic;
using UnityEngine;

public class HealthbarsManager : MonoBehaviour
{
    public static HealthbarsManager Self;
    private HashSet<UnitUIWidget> _uiWidgets = new HashSet<UnitUIWidget>();

    [SerializeField]
    private Camera _mainCamera;

    private Transform _mainCameraTransform;

    private void Awake() // Инициализация zenject
    {
        if (Self == null)
            Self = this;

        _mainCameraTransform = _mainCamera.transform;
    }

    private void Update()
    {
        foreach (UnitUIWidget uiWidget in _uiWidgets)
        {
            if (uiWidget.enabled)
                uiWidget.transform.LookAt(_mainCameraTransform.position, Vector3.up);
        }
    }

    public void AddUIWidget(UnitUIWidget unitUiWidget)
    {
        _uiWidgets.Add(unitUiWidget);
    }

    public void RemoveUIWidget(UnitUIWidget unitUiWidget)
    {
        _uiWidgets.Remove(unitUiWidget);
    }
}
