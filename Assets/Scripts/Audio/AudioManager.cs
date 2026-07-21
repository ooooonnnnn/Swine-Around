using System;
using Audio;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Gameplay.Food;

public class AudioManager : PersistentSingleton<AudioManager>, IAudioManager
{
    private const string BGMStartModeParameter = "BGM Start Mode";

    [SerializeField] private EventReference bgmSound;
    [SerializeField] private EventReference heartCrackSound;
    private const string MASTER_BUS_PATH = "bus:/";
    private const string MUSIC_BUS_PATH = "bus:/Music";
    private const string SFX_BUS_PATH = "bus:/SFX";
    private Bus masterBus, musicBus, sfxBus;

    private EventInstance bgmInstance;

    protected override void Awake()
    { 
        base.Awake();

        if (Instance != this)
            return;

        PlayBGMFirstTimeSound();
    }

    private void Start()
    {
        masterBus = RuntimeManager.GetBus(MASTER_BUS_PATH);
        musicBus = RuntimeManager.GetBus(MUSIC_BUS_PATH);
        sfxBus = RuntimeManager.GetBus(SFX_BUS_PATH);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos = default)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
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
    public void TogglePauseMenuMusic(bool isPaused)
    {
        RuntimeManager.StudioSystem.setParameterByName("IsPaused", isPaused ? 1 : 0);
        sfxBus.setPaused(isPaused);
    }

    public void SetMasterVolume(float volume) => SetBusVolume(masterBus, volume);

    public float GetMasterVolume() => GetBusVolume(masterBus);

    public void SetMusicVolume(float volume) => SetBusVolume(musicBus, volume);

    public float GetMusicVolume() => GetBusVolume(musicBus);

    private void SetBusVolume(Bus bus, float volume)
    {
        bus.setVolume(volume);
    }

    private float GetBusVolume(Bus bus)
    {
        bus.getVolume(out float result);
        return result;
    }
    
    public void SetIsPausedVariable(bool isPaused) // CALL THIS WHEN PAUSED
    {
        RuntimeManager.StudioSystem.setParameterByName("IsPaused", isPaused ? 1 : 0);
    }
    
}
