using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextBtnEvent : MonoBehaviour
{
    // button 오브젝트 가져오는 코드.
    public static Button nextBtn;
    private TMP_Text textNextBtn;
    public static bool nextFlag = false; 

    void Start(){
        nextBtn=GetComponent<Button>();
        textNextBtn = nextBtn.GetComponentInChildren<TMP_Text>();
     }

    void Update(){
        // 오브젝트 활성화/비활성화 하는 코드.
        nextBtn.gameObject.SetActive(nextFlag);
    }

    public void NextBtnClick(){
        // 마지막 문제 맞췄을 때 clear 텍스트로 바꾸기 위한 코드
        if (QuestionAndAnswerTextChanger.trigger>=1){
            textNextBtn.text = "Clear";
        }
        // 마지막 문제 때 next 버튼 클릭시 게임 화면 바꾸기 위한 코드
        if (QuestionAndAnswerTextChanger.trigger>=2){
            changeScene.ChangeScene("index");
        }
        if (TimeManager.timeOverTrigger){
            QuizManager.publicLife--;
        }
        // next 버튼 클릭 후 처리.
        QuestionAndAnswerTextChanger.trigger++;
        TimeManager.time = 10;
        TimeManager.isQuizTimeRunning = true;
        nextBtn.gameObject.SetActive(false);
        nextFlag=false;
        AnswerReader.correctAnswerTrigger = false;
    }
}