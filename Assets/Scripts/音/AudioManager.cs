using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource audioS;
    private void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    public void AudioPlay(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }
}
