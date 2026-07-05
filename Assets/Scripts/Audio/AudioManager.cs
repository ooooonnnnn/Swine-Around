using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Gameplay.Food;

public class AudioManager : PersistentSingleton<AudioManager>
{
    private const string BGMStartModeParameter = "BGM Start Mode";

    [SerializeField] private EventReference bgmSound;
    [SerializeField] private EventReference heartCrackSound;

    private EventInstance bgmInstance;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != this)
            return;

        PlayBGMFirstTimeSound();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos = default)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
    public void PlayOneShot2D(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }
    public void PlayHeartLossSound()
    {
        PlayOneShot(heartCrackSound);
    }

    public void PlayBGMFirstTimeSound()
    {
        if (bgmInstance.isValid())
            return;

        bgmInstance = RuntimeManager.CreateInstance(bgmSound);
        bgmInstance.setParameterByName(BGMStartModeParameter, 0);
        bgmInstance.start();
    }

    public void PlayBGMRestartSound()
    {
        StopBGMSound();

        bgmInstance = RuntimeManager.CreateInstance(bgmSound);
        bgmInstance.setParameterByName(BGMStartModeParameter, 1);
        bgmInstance.start();
    }

    public void StopBGMSound()
    {
        if (!bgmInstance.isValid())
            return;

        bgmInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bgmInstance.release();
        bgmInstance.clearHandle();
    }

    public void ChangeFullnessVariable(FullnessParameters fullnessParameters)
    {
        RuntimeManager.StudioSystem.setParameterByName("fullness", fullnessParameters.currentFullness);
    }
    
}
