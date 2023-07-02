using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscManager : MonoBehaviour
{
    public GameObject escModal;
    public GameObject gameBackBtn;
    public GameObject settingGameBtn;
    public GameObject mainBackBtn;
    public GameObject volumnBar;
    public static bool escFlag = false;
    public static bool settingUiFlag = true;
    // 중요.
    private AudioManager audioManager;    
    void Start()
    {
        // AudioManager에 대한 참조 가져오기
        // 중요.
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update() {            
        escModal.SetActive(escFlag);
        gameBackBtn.SetActive(settingUiFlag);
        settingGameBtn.SetActive(settingUiFlag);
        mainBackBtn.SetActive(settingUiFlag);
        volumnBar.SetActive(settingUiFlag==false);
        // esc 플래그에 따른 모달 컨트롤
        if (Input.GetKeyDown(KeyCode.Escape) && escFlag==false){
            escFlag = true;
            Time.timeScale = 0f;       
            audioManager.audioSource.Pause(); // 멈춤
        }else if(Input.GetKeyDown(KeyCode.Escape) && escFlag!=false) {
            escFlag = false;
            settingUiFlag = true;
            Time.timeScale = 1f;
            audioManager.audioSource.Play(); // 재생
        }
    }
}