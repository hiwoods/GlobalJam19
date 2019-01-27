using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip insideClip;
    public AudioClip outsideClip;

    AudioSource audioSource;

    public CharacterInput player;

    private Coroutine insideRoutine;
    private Coroutine outsideRoutine;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();

        player.OnPlayerStateChanged += OnPlayerStateChanged_EH;
    }

    private void OnPlayerStateChanged_EH(object sender, EventArgs e)
    {
        if (player.IsInSafeZone)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            audioSource.clip = insideClip;
            audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            audioSource.clip = outsideClip;
            audioSource.Play();
        }
    }
}