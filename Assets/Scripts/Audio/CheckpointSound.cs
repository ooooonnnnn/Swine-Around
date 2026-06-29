using FMODUnity;
using UnityEngine;

public class CheckpointSound : MonoBehaviour
{
    [SerializeField] private EventReference sleepSound;
    [SerializeField] private EventReference dropOnMattressSound;
    [SerializeField] private EventReference wakeUpSound;
    
    public void PlaySleepSound()
    {
        AudioManager.Instance.PlayOneShot(sleepSound, transform.position);
    }

    public void PlayDropOnMattressSound()
    {
        AudioManager.Instance.PlayOneShot(dropOnMattressSound, transform.position);
    }

    public void PlayWakeUpSound()
    {
        AudioManager.Instance.PlayOneShot(wakeUpSound, transform.position);
    }
}
