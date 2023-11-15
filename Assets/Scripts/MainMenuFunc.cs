using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunc : MonoBehaviour
{
    public void PressedStart(){

        SceneManager.LoadScene(1);
    }
    public void PressedExit(){
        
        Application.Quit();
    }
    public void PressedMusicOff(){
        
        //SceneManager.LoadScene(0);

    }
    public void PressedSoundEffectOff(){
        
        //SceneManager.LoadScene(0);
    }
    public void PressedTutorial(){
        
        //SceneManager.LoadScene(0);
    }

}
