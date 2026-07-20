using System;
using Audio;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    [SerializeField] private Slider masterSlider, musicSlider;

    private void Start()
    {
        SyncSlidersToVolume();
    }

    public void SyncSlidersToVolume()
    {
        if (!AudioManagerProxy.Instance)
        {
            Debug.LogWarning("AudioManagerProxy not found, can't get volume for sliders");
            return;
        }
        
        masterSlider.value = AudioManagerProxy.Instance.GetMasterVolume();
        musicSlider.value = AudioManagerProxy.Instance.GetMusicVolume();
    }
}
