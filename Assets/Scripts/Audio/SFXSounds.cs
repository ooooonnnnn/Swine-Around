using FMODUnity;
using UnityEngine;

public class SFXSounds : MonoBehaviour
{
    [SerializeField] private EventReference foodCollectionSound;
    [SerializeField] private EventReference defeatSound;
    [SerializeField] private EventReference levelCompleteSound;

    public void PlayFoodCollectionSound()
    {
        AudioManager.Instance.PlayOneShot(foodCollectionSound, transform.position);
    }

    public void PlayDefeatSound()
    {
        AudioManager.Instance.PlayOneShot(defeatSound, transform.position);
    }

    public void PlayLevelCompleteSound()
    {
        AudioManager.Instance.PlayOneShot(levelCompleteSound, transform.position);
    }
}