using UnityEngine;

[RequireComponent(typeof(Unit), typeof(Animator))]
public class Attack : MonoBehaviour
{
    private const string ANIM_PARAM_ATTACK_RATE = "AttackSpeed";
    [SerializeField]
    private Unit _target;

    private Unit _unit;
    private Animator _animator;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _animator = GetComponent<Animator>();

    }

    private void Start() {
        SetAttackSpeed(_unit);
    }

    private void SetAttackSpeed(Unit unit)
    {
        _animator.SetFloat(ANIM_PARAM_ATTACK_RATE, unit.UnitParams.UnitBattleParams.AttackRate);
    }

    public void AnimEvent_Attack()
    {
        if (_target == null)
            return;

        float damage = _unit.UnitParams.UnitBattleParams.Attack;
        _target.Damage(damage);
    }
}
