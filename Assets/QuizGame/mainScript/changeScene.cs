using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // 퀴즈 게임 문제 초기화를 위한 코드
        QuestionAndAnswerTextChanger.trigger = 0;
        NextBtnEvent.nextFlag = false;
    }
}