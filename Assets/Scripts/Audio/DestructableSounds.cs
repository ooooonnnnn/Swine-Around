using FMODUnity;
using UnityEngine;

public class DestructableSounds : BaseSoundPlayer
{
    [SerializeField] private EventReference breakSound;
    [SerializeField] private EventReference breakSoundSecondary;
    public void PlayBreakSound()
    {
        PlayOneShot(breakSound);
        PlayOneShot(breakSoundSecondary);
    }
    
}
