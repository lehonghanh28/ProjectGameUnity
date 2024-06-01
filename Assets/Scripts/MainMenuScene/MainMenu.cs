using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{   
    public TextMeshProUGUI HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //HighScoreText.text = "High score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene1(){
        SceneManager.LoadScene("Assets/Scenes/PlayScene.unity");
    }

    public void LoadGameScene2(){
        SceneManager.LoadScene("Assets/Scenes/PlayScene2.unity");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
