using FMODUnity;
using UnityEngine;

public class GuardSound : MonoBehaviour
{
    private const float IdleSoundInterval = 4f;

    [SerializeField] private EventReference footstepsSound;

    [SerializeField] private EventReference idleSound;
    [SerializeField] private EventReference noticeSound;
    [SerializeField] private EventReference chaseSound;
    [SerializeField] private EventReference forgetSound;

    private bool hasChasedSinceLastPatrol;
    private bool isIdle;
    private float idleSoundTimer;

    private void Update()
    {
        if (!isIdle)
            return;

        idleSoundTimer += Time.deltaTime;
        if (idleSoundTimer < IdleSoundInterval)
            return;

        PlayIdleSound();
        idleSoundTimer -= IdleSoundInterval;
    }

    public void PlaySoundOnStateChange(IPoliceState state)
    {
        string newStateName = state.GetType().Name;
        isIdle = newStateName == "PolicePatrolState";
        idleSoundTimer = 0f;

        switch (newStateName)
        {
            case ("PoliceChaseState"):
                hasChasedSinceLastPatrol = true;
                PlayChaseSound();
                break;
            case ("PolicePatrolState"):
                if (hasChasedSinceLastPatrol)
                {
                    PlayForgetSound();
                    hasChasedSinceLastPatrol = false;
                }
                PlayIdleSound();
                break;
            case ("PoliceSuspicionState"):
                PlayNoticeSound();
                break;
        }
    }
    public void PlayFootstepSound()
    {
        AudioManager.Instance.PlayOneShot(footstepsSound, transform.position);
    }

    public void PlayIdleSound() // START TIMELINE
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
