using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField pName;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score : " + MManager.Instance.highScorePname +" :"+ MManager.Instance.highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        MManager.Instance.pName = pName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
