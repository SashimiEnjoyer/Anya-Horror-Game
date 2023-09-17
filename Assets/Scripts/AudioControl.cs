using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioSourceFadeIn(float fadeTime)
    {
        audioSource.DOFade(1, fadeTime);
    }

    public void AudioSourceFadeOut(float fadeTime)
    {
        audioSource.DOFade(0, fadeTime);
    }
}
