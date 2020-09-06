using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager
{
    [System.Serializable]
    public struct Data
    {

    }

    public struct DataLoadResult
    {
        public bool IsDataLoaded;
        public Data Data;
    }

    public static void SaveData(Data data)
    {
        string saveDirectory = Application.persistentDataPath;
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        string dataFilePath = Path.Combine(saveDirectory, "playerSave.dat");

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = File.Open(dataFilePath, FileMode.OpenOrCreate))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static DataLoadResult LoadData()
    {
        DataLoadResult result = new DataLoadResult();

        string dataFilePath = Path.Combine(Application.persistentDataPath, "playerSave.dat");
        if (File.Exists(dataFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Open(dataFilePath, FileMode.Open))
            {
                result.Data = (Data)formatter.Deserialize(stream);
                result.IsDataLoaded = true;
            }
        }

        return result;
    }
}
