using FMODUnity;
using UnityEngine;

public class DestructableSounds : MonoBehaviour
{
    [SerializeField] private EventReference breakSound;
    public void PlayBreakSound()
    {
        AudioManager.Instance.PlayOneShot(breakSound, transform.position);
    }
    
}
