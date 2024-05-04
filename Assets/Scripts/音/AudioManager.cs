using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource audioS;

    public AudioClip backGround;
    public AudioClip zaoYu;
    public AudioClip zhanDou;
    private void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    public void AudioPlay(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }

    public void AudioChange(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }
}
