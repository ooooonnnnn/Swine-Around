using FMODUnity;
using UnityEngine;
public class FoodSound : MonoBehaviour
{
    [SerializeField] private EventReference foodEatingSound;
    [SerializeField] private EventReference foodChewSound;
    public void PlayFoodSound()
    {
        AudioManager.Instance.PlayOneShot(foodEatingSound, transform.position);
        AudioManager.Instance.PlayOneShot(foodChewSound, transform.position);
    }
}
