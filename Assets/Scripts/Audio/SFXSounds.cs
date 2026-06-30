using FMODUnity;
using UnityEngine;

public class SFXSounds : BaseSoundPlayer
{
    [SerializeField] private EventReference foodCollectionSound;
    [SerializeField] private EventReference defeatSound;
    [SerializeField] private EventReference levelCompleteSound;
    [SerializeField] private EventReference wakeUpOinkSound;

    public void PlayFoodCollectionSound() => PlayOneShot(foodCollectionSound);

    public void PlayDefeatSound() => PlayOneShot(defeatSound);

    public void PlayLevelCompleteSound() => PlayOneShot(levelCompleteSound);
    
    public void PlayWakeUpOinkSound() => PlayOneShot(wakeUpOinkSound);
}