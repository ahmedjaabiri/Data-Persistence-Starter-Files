using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MManager : MonoBehaviour
{
    public static MManager Instance;
    public string pName;
    public int highscore;
    public string highScorePname;
    private void Awake()
    {
        
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        LoadHighScore();
        DontDestroyOnLoad(gameObject);
        

    }
    [System.Serializable]
    class SaveData
    {
        public string pName;
        public int score;
    }
    public void SavePlayerScore()
    {
        SaveData data = new SaveData();
        data.score = highscore;
        data.pName = pName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePname = data.pName;
            highscore = data.score;
        }
        else
        {
            highscore = 0;
        }
    }

}
