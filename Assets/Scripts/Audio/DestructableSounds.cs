using FMODUnity;
using UnityEngine;

public class DestructableSounds : MonoBehaviour
{
    [SerializeField] private EventReference breakSound;
    [SerializeField] private EventReference breakSoundSecondary;
    public void PlayBreakSound()
    {
        AudioManager.Instance.PlayOneShot(breakSound, transform.position);
        AudioManager.Instance.PlayOneShot(breakSoundSecondary, transform.position);
    }
    
}
