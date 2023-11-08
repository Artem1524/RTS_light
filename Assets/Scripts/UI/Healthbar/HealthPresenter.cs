using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField]
    protected Health _health;
    [SerializeField]
    protected Fillable _healthBar;

    private void Start()
    {
        if (_health != null)
        {
            _health.OnHealthChanged += OnHealthChanged;
        }
        UpdateView(_health);
    }

    private void OnDestroy()
    {
        if (_health != null)
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }
    }

    public void Heal(float amount)
    {
        _health?.Increase(amount);
    }

    public void Damage(float amount)
    {
        _health?.Decrease(amount);
    }

    public void Reset()
    {
        _health?.Restore();
    }

    public void OnHealthChanged(Health health)
    {
        UpdateView(health);
    }

    public void UpdateView(Health health)
    {
        if (health == null)
            return;

        if (_healthBar != null && health.MaxHealth != 0)
        {
            _healthBar.SetFillValue(GetHealthPercentage(health));
        }
    }

    private float GetHealthPercentage(Health health)
    {
        return health.CurrentHealth / health.MaxHealth;
    }
}
