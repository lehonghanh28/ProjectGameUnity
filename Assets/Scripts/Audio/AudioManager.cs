using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;
    private bool muted = false;
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else{
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPress(){
        if(muted == false){
            muted = true;
            AudioListener.pause = true;
        }
        else{
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon(){
        if(muted == false){
            musicOn.enabled = true;
            musicOff.enabled = false;
        }
        else{
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
    }

    private void Load(){
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save(){
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
