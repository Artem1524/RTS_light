using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField]
    private Unit _unit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _unit.Damage(125);
    }
}
