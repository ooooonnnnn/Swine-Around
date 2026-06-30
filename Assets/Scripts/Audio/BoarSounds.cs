using FMODUnity;
using UnityEngine;
public class BoarSounds : MonoBehaviour
{
    // [SerializeField] private EventReference footstepsSound;

    [SerializeField] private EventReference oinkSound;
    [SerializeField] private EventReference ramSound;

    // public void PlayFootstepsSound()
    // {
    //     AudioManager.Instance.PlayOneShot(footstepsSound, transform.position);
    // }

    public void PlayOinkSound()
    {
        AudioManager.Instance.PlayOneShot(oinkSound, transform.position);
    }

    public void PlayRamSound()
    {
        AudioManager.Instance.PlayOneShot(ramSound, transform.position);
    }
}
