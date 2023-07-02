using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainManager : MonoBehaviour
{
    public GameObject escModal;
    public static bool escFlag = false;
    void Update() {            
        escModal.SetActive(escFlag);
        // esc 플래그에 따른 모달 컨트롤
        if (Input.GetKeyDown(KeyCode.Escape) && escFlag==false){
            // 게임 일시정지 하기
            Time.timeScale = 0f;
            escFlag = true;
            Debug.Log("esc 눌렸다");
        }else if(Input.GetKeyDown(KeyCode.Escape) && escFlag!=false) {
            Time.timeScale = 1f;
            escFlag = false;
        }
    }
}
