using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    void Start()
    {


        UpdateTutorialText();
        UpdateTutorialImage();
        UpdateTutorialTitle();

    }

    public TextMeshProUGUI title;
    public TextMeshProUGUI tutorialText;

    public GameObject[] Images;

    private string[] titles = {
        "Hareket",
        "Asker Toplama",
        "Lordlarla karşılaşma",
        "Kaleler",
        "Kale Kuşatma"

    };

    private int currentStep = 0;
    private string[] steps = {
        "Ekranda gördüğün Lordu sen yönetiyorsun. Lordunu gitmek istediğin yöne dokunarak ilerletebilirsin.",
        "Bu gördüğün simge asker toplayabileceğin köyleri temsil eder. Bu köylerin üzerinde + simgesi varsa bu köyler asker toplamaya uygun demektir. Dikkat et çok fazla asker toplamak ordunu yavaşlatır.",
        "Diğer lordlarla karşılaşma durumlarında asker sayısı yüksek olan lord her zaman kazanır bu yüzden asker sayına dikkat et.",
        "Kaleler savaşta kaybettiği zaman lordların yeniden doğmasını sağlayan yapıdır. Savaşta kaybeden Lord kalesindeki asker sayısının yarısını alarak tekrar savaşa katılır.",
        "Düşman kaleleri kuşatmak için düşman kalelerine gidebilirsin. Kalelerdeki askerler savunmada daha güçlüdür. Bu yüzden askerlerin düşman askerlerine göre daha hızlı azalır. O yüzden dikkatli ol."
    };

    void UpdateTutorialText()
    {
        tutorialText.text = steps[currentStep];
    }
    void UpdateTutorialImage(){
        foreach(GameObject i in Images){
            i.SetActive(false);
        }
        Images[currentStep].SetActive(true);
    }
    void UpdateTutorialTitle(){
        title.text = titles[currentStep];
    }

    public void NextStep()
    {
        if (currentStep < steps.Length - 1)
        {
            currentStep++;
            UpdateTutorialText();
            UpdateTutorialImage();
            UpdateTutorialTitle();
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            UpdateTutorialText();
            UpdateTutorialImage();
            UpdateTutorialTitle();
        }
    }

    public void PressedMainMenu(){
        SceneManager.LoadScene(0);
        
    }
}
