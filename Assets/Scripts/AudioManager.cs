using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    [SerializeField] private AudioSource AS;
    [SerializeField] public AudioClip successClip, failedClip, masteredClip;

    public void PlayAudio(AudioClip clip)
    {
        AS.volume = Settings.SfxVolume;
        AS.PlayOneShot(clip);
    }
}
