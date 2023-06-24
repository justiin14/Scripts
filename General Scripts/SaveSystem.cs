using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveData(Tracker tracker)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.sv";

        FileStream fs = new FileStream(path, FileMode.Create);

        Data data = new Data(tracker);

        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static Data LoadSave()
    {
        string path = Application.persistentDataPath + "/data.sv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fs) as Data;
            fs.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
