using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] music;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[0];
        audioSource.Play();
    }
}
