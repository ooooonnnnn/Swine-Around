using FMODUnity;
using UnityEngine;

public class CheckpointSound : BaseSoundPlayer
{
    [SerializeField] private EventReference sleepSound;
    [SerializeField] private EventReference dropOnMattressSound;
    [SerializeField] private EventReference wakeUpSound;
    
    public void PlaySleepSound() => PlayOneShot(sleepSound);

    public void PlayDropOnMattressSound() => PlayOneShot(dropOnMattressSound);

    public void PlayWakeUpSound() => PlayOneShot(wakeUpSound);
}
