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
        string saveJson = EncryptAES.Encrypt256(JsonUtility.ToJson(data), "DONTPASSHARIHARU1221AES256KEY");
        
        string saveFilePath = SavePath + saveFilename + ".json";

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save : " + saveFilePath);
    }

    public static T Load<T>(string saveFileName) where T : Data, new()
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log(typeof(T).Name + " »ý¼º");
            T data = new T();
            Save<T>(data, saveFileName);
            return data;
        }

        string saveFile = EncryptAES.Decrypt256(File.ReadAllText(saveFilePath), "DONTPASSHARIHARU1221AES256KEY");
        T saveData = JsonUtility.FromJson<T>(saveFile);
        return saveData;
    }
}

//"DONTPASSHARIHARU1221AES256KEY"