using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; // Thread문 사용을 위한 using 문
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro 바꾸기 위한 using 문
[System.Serializable]

public class QuizManager : MonoBehaviour
{
    public TMP_Text life;
    // 다음 버튼 활성화를 위한 변수
    public static bool clearFlag = false;
    void Update(){        
        // 목숨 수를 life 오브젝트에 넣는 함수.
        life.text = choiceDifficulty.difficulty.ToString();

        // 목숨이 0이 되면 gameOver 화면으로 넘어가게 함.
        if( choiceDifficulty.difficulty==0){
            changeScene.ChangeScene("gameOverQ");
        }
        // 클리어 버튼 활성화/비활성화 하기 위한 코드.
    }


}