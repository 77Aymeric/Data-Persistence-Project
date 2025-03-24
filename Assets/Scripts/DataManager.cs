using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentPlayerName;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}