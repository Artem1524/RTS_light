using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Attack : MonoBehaviour
{
    [SerializeField]
    private Unit _target;

    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    public void AnimEvent_Attack()
    {
        if (_target == null)
            return;

        float damage = _unit.UnitParams.UnitBattleParams.Attack;
        _target.Damage(damage);
    }
}
