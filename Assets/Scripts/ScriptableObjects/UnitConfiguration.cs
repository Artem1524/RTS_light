using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitConfiguration", menuName = "Configs/Unit Configuration")]
public class UnitConfiguration : ScriptableObject
{
    [SerializeField]
    private UnitType _unitType;
    [SerializeField]
    private UnitParams _unitParams;

    public UnitType UnitType => _unitType;
    public UnitParams UnitParams => _unitParams;
}
