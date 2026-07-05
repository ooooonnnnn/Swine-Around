using System;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class RandomVideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] clips;
    public UnityEvent OnVideoStartPlaying;

    private void OnValidate()
    {
        if (!videoPlayer)
            videoPlayer = GetComponent<VideoPlayer>();
    }

    [ContextMenu("Play Random Video")]
    public void PlayRandomVideo()
    {
        OnVideoStartPlaying.Invoke();
        videoPlayer.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        videoPlayer.time = 0;
        videoPlayer.Play();
    }
}
