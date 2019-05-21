using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerStats ps) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(ps);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path)) {
            Debug.Log("Existe");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

        public static void SaveEnemy(Enemy enemy) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/enemy.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        EnemyData data = new EnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EnemyData LoadEnemy() {
        string path = Application.persistentDataPath + "/enemy.fun";
        if(File.Exists(path)) {
            Debug.Log("Existe");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGame(PlayerStats ps, Enemy enemy) {
        Debug.Log("Saving Game!");
        SavePlayer(ps);
        SaveEnemy(enemy);
    }

    public static void LoadGame(PlayerStats ps, Enemy enemy) {
        Debug.Log("Loading Game!");
        LoadPlayer();
        LoadEnemy();
    }
}
