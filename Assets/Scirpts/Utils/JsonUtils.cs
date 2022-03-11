using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JsonUtils
{
    private static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save(SaveData data, string saveFilename)
    {
        if(!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }

        string saveJson = JsonUtility.ToJson(data);

        string saveFilePath = SavePath + saveFilename + ".json";

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save : " + saveFilePath);
    }

    public static void SaveintData(string name, int data, string saveFilename)
    {
        SaveData saveData = Load(saveFilename);
        if (saveData == null) return;
        
        if (saveData.IntData.ContainsKey(name))
        {
            saveData.IntData[name] = data;
        }
        else
        {
            saveData.IntData.Add(name, data);
        }

        Save(saveData, saveFilename);
    }

    public static SaveData Load(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("NoneFile");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
}
