using FMODUnity;
using UnityEngine;

public class CheckpointSound : MonoBehaviour
{
    [SerializeField] private EventReference sleepSound;
    [SerializeField] private EventReference dropOnMattressSound;
    [SerializeField] private EventReference wakeUpSound;
    
    public void PlaySleepSound() => PlaySound(sleepSound);

    public void PlayDropOnMattressSound() => PlaySound(dropOnMattressSound);

    public void PlayWakeUpSound() => PlaySound(wakeUpSound);

    private void PlaySound(EventReference sound)
    {
        if (!AudioManager.Instance)
            return;
        AudioManager.Instance.PlayOneShot(sound, transform.position);
    }
}
