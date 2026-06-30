using FMODUnity;
using UnityEngine;

public class GuardSound : BaseSoundPlayer
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
    public void PlayFootstepSound() => PlayOneShot(footstepsSound);

    public void PlayIdleSound() => PlayOneShot(idleSound);// START TIMELINE

    public void PlayNoticeSound() => PlayOneShot(noticeSound);

    public void PlayChaseSound() => PlayOneShot(chaseSound);

    public void PlayForgetSound() => PlayOneShot(forgetSound);
}
