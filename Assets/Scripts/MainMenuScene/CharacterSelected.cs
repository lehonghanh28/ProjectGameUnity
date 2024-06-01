using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;

    public Button unlockButton;
    public TextMeshProUGUI coinText;
    private void Awake(){
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject player in skins){
            player.SetActive(false);
        }
        skins[selectedCharacter].SetActive(true);

        foreach(Character c in characters){
            if(c.price == 0){
                c.isUnlocked = true;
            }
            else{
                if(PlayerPrefs.GetInt(c.name, 0) == 0){
                    c.isUnlocked = false;
                }
                else{
                    c.isUnlocked = true;
                }
            }
        }
        UpdateUI();
    }
    
    public void ChangeNext(){
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if(selectedCharacter == skins.Length){
            selectedCharacter = 0;
        }
        skins[selectedCharacter].SetActive(true);
        if(characters[selectedCharacter].isUnlocked){
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }
        UpdateUI();
    }
    public void ChangePrevious(){
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter == -1){
            selectedCharacter = skins.Length - 1;
        }
        skins[selectedCharacter].SetActive(true);
        if(characters[selectedCharacter].isUnlocked){
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }        
        UpdateUI();
    }

    public void UpdateUI(){
        coinText.text = "Coins: " + PlayerPrefs.GetInt("numberCoins", 0);
        if(characters[selectedCharacter].isUnlocked == true){
            unlockButton.gameObject.SetActive(false);
        }
        else{
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[selectedCharacter].price;
            if(PlayerPrefs.GetInt("numberCoins", 0) < characters[selectedCharacter].price){
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else{
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock(){
        int coins = PlayerPrefs.GetInt("numberCoins", 0);
        int price = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("numberCoins", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked  = true;
        UpdateUI();
    }
}
