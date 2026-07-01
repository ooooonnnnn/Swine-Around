using FMODUnity;
using UnityEngine;
public class FoodSound : BaseSoundPlayer
{
    [SerializeField] private EventReference foodEatingSound;
    [SerializeField] private EventReference foodChewSound;
    public void PlayFoodSound()
    {
        PlayOneShot(foodEatingSound);
        PlayOneShot(foodChewSound);
    }
}
