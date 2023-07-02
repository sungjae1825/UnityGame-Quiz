using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; // Text 컴포넌트에 접근하기 위해 추가해야 할 using 문
using TMPro; // TextMeshPro 바꾸기 위한 using 문
using UnityEngine;

public class AnswerReader : MonoBehaviour
{    
    private string answer;
    public static bool correctAnswerTrigger = false;
    private Image CorrectUI;
    private Image WrongUI;


    private void Start()
    {
        CorrectUI.gameObject.SetActive(false);
        WrongUI.gameObject.SetActive(false);
    }

    private void Awake()
    {
        CorrectUI = GameObject.Find("Canvas/Correct").GetComponent<Image>();
        WrongUI = GameObject.Find("Canvas/Wrong").GetComponent<Image>();
    }
    // 답 선택시 답배열에 답이 있는지 확인하는 함수.
    public void AnswerReaderHandler()
    {
        // 클릭한 button의 text를 가져와서 answer 변수에 넣음.
        TextMeshProUGUI textMesh = GetComponentInChildren<TextMeshProUGUI>();
        answer = textMesh.text;
        // 배열에 답을 확인하는 함수.
        if (Array.IndexOf(QuestionAndAnswerTextChanger.answerList, answer) != -1){
            NextBtnEvent.nextFlag = true;
            correctAnswerTrigger = true;
            NextBtnEvent.nextBtn.gameObject.SetActive(NextBtnEvent.nextFlag);
            CorrectUI.gameObject.SetActive(true);
            StartCoroutine(HideLifeLostText());
            TimeManager.isQuizTimeRunning = false;
        }else if (correctAnswerTrigger){}
        else{
            WrongUI.gameObject.SetActive(true);
            StartCoroutine(HideLifeLostText());
            QuizManager.publicLife--;
        }
    }



    private IEnumerator HideLifeLostText()
    {
        yield return new WaitForSeconds(0.3f);
        CorrectUI.gameObject.SetActive(false);
        WrongUI.gameObject.SetActive(false);

    }
}