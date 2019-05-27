using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SavePlayerData()
    {
        PlayerStats ps = GameManager.instance.getPlayerStats();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(ps);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
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

    public static void SaveEdibles() 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/edibles.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameObject[] listOfEdibles = GameObject.FindGameObjectsWithTag("Eatable");
        EdibleData[] listOfData = new EdibleData[listOfEdibles.Length];
        int index = 0;
        foreach(GameObject edibleObject in listOfEdibles)
        {
            EdibleData edibleData = edibleObject.GetComponent<BaseEdible>().m_data;
            Debug.Log("Saving Edible: " + edibleData.prefabIndex + " size: " + edibleData.size);
            listOfData[index++] = edibleData;
        }

        formatter.Serialize(stream, listOfData);
        stream.Close();
    }

    public static EdibleData[] LoadEdibles() {
        string path = Application.persistentDataPath + "/edibles.fun";
        if(File.Exists(path)) {
            Debug.Log(path);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EdibleData[] edibleDatas = formatter.Deserialize(stream) as EdibleData[];

            foreach (EdibleData ed in edibleDatas)
            {
                Debug.Log("Restoring Edible: " + ed.prefabIndex + " size: " + ed.size);
            }
            stream.Close();
            return edibleDatas;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGame()
    { 
        SavePlayerData();
        SaveEdibles();
    }

    public static void LoadGame()
    {
        foreach (GameObject edibleObject in GameObject.FindGameObjectsWithTag("Eatable"))
        {
            GameObject.Destroy(edibleObject, 0.1f);
        }


        GameManager.instance.Invoke("spawnEdiblesFromLastSave", 0.25f);
        GameManager.instance.Invoke("spawnPlayerFromLastSave", 0.25f);
    }




    public static void SaveRanking()
    {
        Debug.Log("Saving Ranking!!");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ranking.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerStatsData[] rankingData = GameManager.instance.playerRanking;

        for (int i = 0; i < rankingData.Length; i++)
        {
            if (rankingData[i] != null)
                Debug.Log("STORING CALORIES: " + rankingData[i].calories);
        }

        formatter.Serialize(stream, rankingData);
        stream.Close();
    }

    public static PlayerStatsData[] LoadRanking()
    {
        string path = Application.persistentDataPath + "/ranking.fun";
        if (File.Exists(path))
        {
            Debug.Log(path);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerStatsData[] rankingData = formatter.Deserialize(stream) as PlayerStatsData[];

            stream.Close();
            return rankingData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return new PlayerStatsData[3];
        }
    }
}
