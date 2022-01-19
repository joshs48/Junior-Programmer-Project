using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public string playerName;
    public int highscore;
    public string hsPlayerName;

    public static StartManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        ReadData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void Save()
    {
        SaveData data = new SaveData();
        data.hsplayerName = hsPlayerName;
        data.highScore = highscore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void ReadData()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            hsPlayerName = data.hsplayerName;
            highscore = data.highScore;
            
        }
    
    }

    class SaveData
    {
        public string hsplayerName;
        public int highScore;
    }

    public void GetName()
    {
        playerName = GameObject.Find("Canvas").transform.Find("Name input").GetComponent<InputField>().text;
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

}
