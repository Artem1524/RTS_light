using System;

[Serializable]
public struct Unit : IUnit
{
    public BaseParams UnitBaseParams;
    public BattleParams UnitBattleParams;

    public float MoveSpeed;
}
