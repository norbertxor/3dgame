using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    public static void SaveData(float health, float posX, float posY, float posZ) {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(health, posX, posY, posZ);
        
        binary.Serialize(file, data);
        
        file.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path)) {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            PlayerData data = binary.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else {
            Debug.LogError("Error Data loading, file not find " + path);
            return null;
        }
    }
}