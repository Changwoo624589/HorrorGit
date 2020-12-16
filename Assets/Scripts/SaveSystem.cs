
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    public static void SaveSettings(CamLook camLook)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/settingSave.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(camLook);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadSettings()
    {
        string path = Application.dataPath + "/settingSave.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }


        }
        else 
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
