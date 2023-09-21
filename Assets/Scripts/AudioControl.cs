using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    private float initialVolumne;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialVolumne = audioSource.volume;
        audioSource.Play();
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioSourceFadeIn(float fadeTime)
    {
        audioSource.DOFade(initialVolumne, fadeTime);
    }

    public void AudioSourceFadeOut(float fadeTime)
    {
        audioSource.DOFade(initialVolumne, fadeTime);
    }
}
