using System.Collections.Generic;
using UnityEngine;

public class UnitConfigsSetupManager : MonoBehaviour
{
    public static UnitConfigsSetupManager Self;

    private const string PATH_TO_CONFIGURATIONS = "Configurations/ScriptableObjects/UnitParams/";

    private readonly Dictionary<UnitType, UnitParams> unitTypeParams = new Dictionary<UnitType, UnitParams>();

    private bool isInitialized = false;

    private void Awake()
    {
        if (Self == null)
        {
            Self = this;
        }
    }

    private void LazySetupParams()
    {
        UnitConfiguration[] configs = Resources.LoadAll<UnitConfiguration>(PATH_TO_CONFIGURATIONS);

        foreach (UnitConfiguration config in configs)
        {
            unitTypeParams.TryAdd(config.UnitType, config.UnitParams);
        }

        isInitialized = true;
    }

    public UnitParams GetUnitParameters(UnitType unitType)
    {
        if (!isInitialized)
            LazySetupParams();

        unitTypeParams.TryGetValue(unitType, out UnitParams unitParams);
        return unitParams;
    }
}
