using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // 오디오를 재생할 AudioSource 컴포넌트

    void Start()
    {
        // MP3 파일을 재생할 오디오 클립을 로드
        AudioClip audioClip = Resources.Load<AudioClip>("MainSound");

        // AudioSource에 오디오 클립 할당
        audioSource.clip = audioClip;

        // 오디오 재생
        audioSource.Play();
    }
}