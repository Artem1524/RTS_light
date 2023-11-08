using UnityEngine;

public class UnitUIWidget : MonoBehaviour
{
    private void Start()
    {
        HealthbarsManager.Self.AddUIWidget(this);
    }

    private void OnDisable()
    {
        HealthbarsManager.Self.RemoveUIWidget(this);
    }

    private void OnBecameVisible() // Уточнить
    {
        gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
