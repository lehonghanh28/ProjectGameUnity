using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Assets/Scenes/MainMenuScene.unity");
    }

    public void LoadPlayScene(){
        SceneManager.LoadScene("Assets/Scenes/PlayScene.unity");
    }
    public void LoadPlayScene2(){
        SceneManager.LoadScene("Assets/Scenes/PlayScene2.unity");
    }

}
