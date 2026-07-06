using System;
using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class RandomVideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] clips;
    public UnityEvent OnVideoStartPlaying;
    public UnityEvent OnVideoEndPlaying;

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
        StartCoroutine(ExecuteAfterTime(videoPlayer.clip.length));
    }
    IEnumerator ExecuteAfterTime(double time)
    {
        yield return new WaitForSeconds((float)time);

        OnVideoEndPlaying.Invoke();
    }
}
