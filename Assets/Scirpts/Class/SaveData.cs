using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public SaveData()
    {
        intData = new Dictionary<string, int>();
        floatData = new Dictionary<string, float>();
    }

    private Dictionary<string, int> intData;
    public Dictionary<string, int> IntData { get => intData; set => intData = value; }
    private Dictionary<string, float> floatData;
    public Dictionary<string, float> FloatData { get => floatData; set => floatData = value; }
}