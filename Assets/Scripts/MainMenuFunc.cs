using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunc : MonoBehaviour
{

    [SerializeField]
    private Color offColor;
    [SerializeField]
    private Image musicImage;
    [SerializeField]
    private Image soundEffectsImage;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music",1);
            musicImage.color = Color.white;
        }
        else
        {
            
            if (PlayerPrefs.GetInt("music")==1)
            {
                musicImage.color = Color.white;
            }
            else
            {

                musicImage.color = offColor;
            }
        }    
        
        if (!PlayerPrefs.HasKey("soundEffects"))
        {
            PlayerPrefs.SetInt("soundEffects",1);
            soundEffectsImage.color = Color.white;
        }
        else
        {
            
            if (PlayerPrefs.GetInt("soundEffects")==1)
            {
                soundEffectsImage.color = Color.white;
            }
            else
            {

                soundEffectsImage.color = offColor;
            }
        }    
    }

    public void PressedStart(){

        SceneManager.LoadScene(1);
    }
    public void PressedExit(){
        
        Application.Quit();
    }
    public void PressedMusicOff(){

        if (PlayerPrefs.GetInt("music")==1)
        {
            PlayerPrefs.SetInt("music", 0);
            musicImage.color = offColor;
        }
        else
        {
            PlayerPrefs.SetInt("music",1);
            musicImage.color = Color.white;
        }

    }
    public void PressedSoundEffectOff(){

        if (PlayerPrefs.GetInt("soundEffects")==1)
        {
            PlayerPrefs.SetInt("soundEffects", 0);
            soundEffectsImage.color = offColor;
        }
        else
        {
            PlayerPrefs.SetInt("soundEffects",1);
            soundEffectsImage.color = Color.white;
        }
        
    }
    public void PressedTutorial(){
        SceneManager.LoadScene(2);
        
    }

    
    

}
