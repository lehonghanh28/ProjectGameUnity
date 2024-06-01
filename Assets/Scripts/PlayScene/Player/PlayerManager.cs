using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverPanel, scoreText;
    public TextMeshProUGUI FinalScoreText, HighScoreText;
    public static bool gameOver = false;
    public GameObject[] playerPrefabs;
    int characterIndex;
    private void Awake(){
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPrefabs[characterIndex], new Vector3(-9.64f, -2.23f, 0) , Quaternion.identity);
        gameOver = false;
    }
    void Start()
    { 
        //GameObject.FindGameObjectWithTag("Player").GetComponent(Animator)<>
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){
            StartCoroutine("ShowGameOverPanel");
        }
    }

    IEnumerator ShowGameOverPanel(){
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text = "Score: " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;

        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
