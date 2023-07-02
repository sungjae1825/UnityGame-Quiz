using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnController : MonoBehaviour
{
    public Slider slider;
    private AudioManager audioManager;    
    void Start()
    {
        // AudioManager에 대한 참조 가져오기
        // 중요.
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        // 슬라이더의 값을 콘솔에 출력합니다.
        // Debug.Log("Slider Value: " + slider.value);
        //audioManager.audioSource.volume = slider.value;
    }
}