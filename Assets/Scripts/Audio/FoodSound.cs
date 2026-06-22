using FMODUnity;
using UnityEngine;
public class FoodSound : MonoBehaviour
{
    [SerializeField] private EventReference FoodEatingSound;
    [SerializeField] private EventReference FoodCollectionSoundSound;
    public void PlayFoodSound()
    {
        AudioManager.Instance.PlayOneShot(FoodCollectionSoundSound, transform.position);
        AudioManager.Instance.PlayOneShot(FoodEatingSound, transform.position);
    }
}
