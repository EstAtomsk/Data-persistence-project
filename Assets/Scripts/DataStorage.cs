using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;

    public string playerName;
    public int highScore;
    public string currentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveDataMethod()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataMethod()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
