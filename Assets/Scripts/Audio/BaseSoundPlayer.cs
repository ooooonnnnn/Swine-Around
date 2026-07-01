using FMODUnity;
using UnityEngine;

public class BaseSoundPlayer : MonoBehaviour
{
    protected void PlayOneShot(EventReference sound)
    {
        if (!AudioManager.Instance)
            return;
        AudioManager.Instance.PlayOneShot(sound, transform.position);
    }
}
