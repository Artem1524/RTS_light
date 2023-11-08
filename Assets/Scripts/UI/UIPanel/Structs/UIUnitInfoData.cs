using System;

[Serializable]
public struct UIUnitInfoData
{
    public string ParamTextureName;
    public string ParamTitle;
    public string ParamValue;

    public UIUnitInfoData(string textureName, string paramTitle, string paramValue)
    {
        ParamTextureName = textureName;
        ParamTitle = paramTitle;
        ParamValue = paramValue;
    }
}
