using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer vidPlayer;
    [SerializeField] private UnityEvent eventAfterVideo;

    private void Awake()
    {
        vidPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        eventAfterVideo?.Invoke();
    }

    private void OnDestroy()
    {
        vidPlayer.loopPointReached -= OnVideoFinished;
    }
}
