using FMODUnity;
using UnityEngine;

public class GuardSound : MonoBehaviour
{
    [SerializeField] private EventReference footstepsSound;

    [SerializeField] private EventReference idleSound;
    [SerializeField] private EventReference noticeSound;
    [SerializeField] private EventReference chaseSound;
    [SerializeField] private EventReference forgetSound;

    public void PlayFootstepsSound()
    {
        AudioManager.Instance.PlayOneShot(footstepsSound, transform.position);
    }

    public void PlayIdleSound()
    {
        AudioManager.Instance.PlayOneShot(idleSound, transform.position);
    }

    public void PlayNoticeSound()
    {
        AudioManager.Instance.PlayOneShot(noticeSound, transform.position);
    }

    public void PlayChaseSound()
    {
        AudioManager.Instance.PlayOneShot(chaseSound, transform.position);
    }

    public void PlayForgetSound()
    {
        AudioManager.Instance.PlayOneShot(forgetSound, transform.position);
    }
}
