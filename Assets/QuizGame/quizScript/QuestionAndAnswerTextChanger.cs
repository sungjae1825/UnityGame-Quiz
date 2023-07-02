using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text 컴포넌트에 접근하기 위해 추가해야 할 using 문
using TMPro; // TextMeshPro 바꾸기 위한 using 문

public class QuestionAndAnswerTextChanger : MonoBehaviour
{
    public GameObject questionBox;
    public TMP_Text firstAnswerBox;
    public TMP_Text secondAnswerBox;
    public TMP_Text thirdAnswerBox;
    public TMP_Text fourthAnswerBox;

    // 퀴즈 문제와 답을 바꾸기 위한 변수.
    public static int trigger = 0;


    string[] questions = {"다음중 물음표에 들어갈 숫자는?           16 06 68 88 ? 98", "다음 자막으로 낱말을 만든다면?           ㅈ ㅏ ㄹ ㅜ ㅁ ㅏ ㄷ ㅣ", "다음중 물음표에 들어갈 알파벳은?           MMCMM?M"};
    string[,] answers = {{"87", "94", "76", "53"}, {"물고기", "동물", "도시", "행성"}, {"M", "C", "R", "K"}};
    public static string[] answerList = {"87", "동물", "K"};

    void Update(){
        // 문제수가 3개라 오류 잡기 위한 코드.
        if (trigger == 3){
            trigger=2;
        }

        Text questionText = questionBox.GetComponent<Text>();

        questionText.text = questions[trigger];
        firstAnswerBox.text = answers[trigger,0];
        secondAnswerBox.text =answers[trigger,1];
        thirdAnswerBox.text = answers[trigger,2];
        fourthAnswerBox.text =answers[trigger,3];
    }
    // Start is called before the first frame update

}