using UnityEngine;
using System.IO;

public class JsonUtils
{
    private static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save<T>(T data, string saveFilename) where T : Data, new()
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

    public static T Load<T>(string saveFileName) where T : Data, new()
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log(typeof(T).Name + " ����");
            return new T();
        }

        string saveFile = File.ReadAllText(saveFilePath);
        T saveData = JsonUtility.FromJson<T>(saveFile);
        return saveData;
    }
}
