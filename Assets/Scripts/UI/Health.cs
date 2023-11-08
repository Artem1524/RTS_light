using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<Health> OnHealthChanged;

    [SerializeField]
    private float _maxHealth = 100f;
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _healthRegen = 0f;

    public float MaxHealth
    {
        get => _maxHealth;
        private set => _maxHealth = (value < 0) ? 0 : value;
    }

    public float CurrentHealth
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, _maxHealth);
    }

    public void Increase(float amount)
    {
        CurrentHealth += amount;
        UpdateHealth(this);
    }

    public void Decrease(float amount)
    {
        CurrentHealth -= amount;
        UpdateHealth(this);
    }

    public void Restore()
    {
        CurrentHealth = MaxHealth;
        UpdateHealth(this);
    }

    public void SetMaxHealth(float amount)
    {
        MaxHealth = amount;
    }

    public void UpdateHealth(Health health)
    {
        OnHealthChanged?.Invoke(health);
    }
}
