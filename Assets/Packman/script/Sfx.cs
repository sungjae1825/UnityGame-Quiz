using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Coins_Few_00");
    }

    // Update is called once per frame
    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip)
;    }
}
