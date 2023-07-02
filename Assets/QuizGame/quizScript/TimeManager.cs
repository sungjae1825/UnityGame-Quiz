using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static float time = 10;
    public static bool isQuizTimeRunning = true;
    public static bool timeOverTrigger = false;

    public TMP_Text timer;
    public TMP_Text timeOverUi;
    void Update()
    {
        // Debug.Log(time);
        if (isQuizTimeRunning){
            time -= Time.deltaTime;
            AnswerReader.correctAnswerTrigger = false;
        }
        if(time<=0.5f){
            isQuizTimeRunning = false;
        }
        if(isQuizTimeRunning == false && timer.text == "0") {
            timeOverTrigger = true;

            AnswerReader.correctAnswerTrigger = true;
            NextBtnEvent.nextBtn.gameObject.SetActive(true);
            NextBtnEvent.nextFlag = true;
        }
        if (isQuizTimeRunning == true && AnswerReader.correctAnswerTrigger == false){
            timeOverTrigger = false;
            NextBtnEvent.nextBtn.gameObject.SetActive(false);
            NextBtnEvent.nextFlag = false;
        }
        timeOverUi.enabled = timeOverTrigger;
        timer.text = time.ToString("F0");
    }
}