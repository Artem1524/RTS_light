using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour, IUnit
{
    public event Action<Unit> OnDie;

    [SerializeField]
    private UnitType _unitType;
    [SerializeField]
    private SelectionCirclePoint _selectionCirclePoint;

    private UnitParams _unitParams;
    private Health _health;

    public UnitParams UnitParams => _unitParams;
    public UnitType UnitType => _unitType;
    public Health UnitHealth => _health;
    public SelectionCirclePoint SelectionCirclePoint => _selectionCirclePoint;

    private void Awake()
    {
        TryGetComponent(out _health);
        _unitParams = UnitConfigsSetupManager.Self.GetUnitParameters(_unitType);
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        _health.SetMaxHealth(_unitParams.UnitBaseParams.MaxHealth);
        _health.CurrentHealth = _health.MaxHealth;
        //_health.HealthRegen = _unitParams.UnitBaseParams.HealthRegen;
    }

    public void Damage(float amount)
    {
        float armor = _unitParams.UnitBaseParams.Armor;

        float actualArmor = Mathf.Clamp(armor, 0f, 90f);
        float damage = amount * (1 - actualArmor * 0.01f);

        if (damage > 0)
            _health.Decrease(damage);
    }

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
