using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> OnHealthChanged;

    private float _maxHealth = 0;
    private float _health;

    public float MaxHealth
    {
        get => _maxHealth;
        private set => _maxHealth = (value < 0) ? 0 : value;
    }

    public float CurrentHealth
    {
        get => _health;
        set => Mathf.Clamp(value, 0, _maxHealth);
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}
