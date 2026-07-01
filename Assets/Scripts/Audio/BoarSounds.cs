using FMODUnity;
using UnityEngine;
public class BoarSounds : BaseSoundPlayer
{
    // [SerializeField] private EventReference footstepsSound;

    [SerializeField] private EventReference oinkSound;
    [SerializeField] private EventReference ramSound;

    // public void PlayFootstepsSound()
    // {
    //     AudioManager.Instance.PlayOneShot(footstepsSound, transform.position);
    // }

    public void PlayOinkSound() => PlayOneShot(oinkSound);

    public void PlayRamSound() => PlayOneShot(ramSound);
}
