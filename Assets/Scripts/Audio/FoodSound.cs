using FMODUnity;
using UnityEngine;
public class FoodSound : MonoBehaviour
{
    [SerializeField] private EventReference foodEatingSound;
    public void PlayFoodSound()
    {
        AudioManager.Instance.PlayOneShot(foodEatingSound, transform.position);
    }
}
