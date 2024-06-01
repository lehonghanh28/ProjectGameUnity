using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{   
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().gameOver
        if(PlayerManager.gameOver){
            if(PlayerPrefs.GetInt("HighScore") < score){
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High score is " + score);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Obstacle")){
            score += 1;
            scoreText.text = "Score : " + score;
        }
    }
}
