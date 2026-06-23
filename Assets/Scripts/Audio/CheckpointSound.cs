using FMODUnity;
using UnityEngine;

public class CheckpointSound : MonoBehaviour
{
    [SerializeField] private EventReference sleepSound;
    
    public void PlaySleepSound()
    {
        AudioManager.Instance.PlayOneShot(sleepSound, transform.position);
    }
}