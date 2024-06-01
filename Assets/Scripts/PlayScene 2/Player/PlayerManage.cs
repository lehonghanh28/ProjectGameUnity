using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver1 = false;
    public static int numberCoins;
    public GameObject GameOverPanel;
    public TextMeshProUGUI coinText, FinalCoinText;
    public GameObject[] playerPrefabs2;
    int characterIndex;
    private void Awake(){
        numberCoins = PlayerPrefs.GetInt("numberCoins", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPrefabs2[characterIndex], new Vector3(-9.64f, -2.23f, 0) , Quaternion.identity);
        gameOver1 = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        coinText.text = " " + numberCoins;
        if(gameOver1 == true){
            StartCoroutine("ShowGameOverPanel");
        }
    }

    IEnumerator ShowGameOverPanel(){
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        FinalCoinText.text = "Coin collect:" + coinText.text;

    }   
}
