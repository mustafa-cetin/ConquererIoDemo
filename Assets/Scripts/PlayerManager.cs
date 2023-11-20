using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI soldierText;

    public TextMeshProUGUI killCountText;
    public GameObject endGameScreen;
    private float Timer=2f;
    public int killCount=0;


    public TextMeshProUGUI endKillText;

    public TextMeshProUGUI winKillText;
    public GameObject endWinGameScreen;

    public TextMeshProUGUI startText;
    private AudioSource audioSource;

    public AudioClip warSong;
    public AudioClip swordClash;
    public AudioClip bloodySword;
    public AudioClip maleHurt;
    public AudioClip questSucceed;
    private GameObject[] castles;
    public bool playedSong;
    private void Start() {
        audioSource=GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("music")==1)
        {
            audioSource.clip=warSong;
            audioSource.Play();
        }

        castles=GameObject.FindGameObjectsWithTag("Castle");
        playedSong=false;
       StartCoroutine(Texter(startText,"CONQUER ALL CASTLES"));
    }

    public void AlertSoldierAdd(int soldierCount){
       StartCoroutine(Texter(soldierText,"+"+soldierCount));

    }
    private void Update() {
        WinCheck();
    }
    IEnumerator Texter(TextMeshProUGUI text,string textstring){
        text.gameObject.SetActive(true);
        text.text=textstring;
        yield return new WaitForSeconds(1f);
        text.text="";
        text.gameObject.SetActive(false);
    }
    public void killCountIncrease(){
        if (PlayerPrefs.GetInt("soundEffects")==1)
        {
            audioSource.PlayOneShot(bloodySword);
        }

        killCount+=1;
        killCountText.text="Kill: "+killCount;
        SetMaxKillCount(killCount);
    }
    public void Death(){
        audioSource.Stop();
        endKillText.text="KILL COUNT: "+killCount.ToString();
        SetMaxKillCount(killCount);
        endGameScreen.SetActive(true);
        Time.timeScale=0;
    }
    public void Win(){
        audioSource.Stop();
        endKillText.text="KILL COUNT: "+killCount.ToString();
        SetMaxKillCount(killCount);
        endGameScreen.SetActive(true);
        Time.timeScale=0;
    }
    public void Conquered(){
        if (PlayerPrefs.GetInt("soundEffects")==1)
        {

            audioSource.PlayOneShot(swordClash);
        }
        audioSource.PlayOneShot(swordClash);
        StartCoroutine(Texter(soldierText,"Kale fethedildi."));
    }
    public void onDie(){
        if (PlayerPrefs.GetInt("soundEffects")==1)
        {

            audioSource.PlayOneShot(maleHurt);
        }
    }
    public void WinCheck(){
        if (player.GetComponent<Lord>().castles.Count==castles.Length)
        {
            if (!playedSong)
            {

        audioSource.PlayOneShot(questSucceed);
        playedSong=true;
            }
        winKillText.text="KILL COUNT: "+killCount.ToString();
        SetMaxKillCount(killCount);
        endWinGameScreen.SetActive(true);
        Time.timeScale=0;
        }
    }
    public void RestartGame(){
        Time.timeScale=1;
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void SetMaxKillCount(int killCount){
        if (PlayerPrefs.GetInt("killCount")<killCount)
        {
            PlayerPrefs.SetInt("killCount",killCount);
        }
    }
}
