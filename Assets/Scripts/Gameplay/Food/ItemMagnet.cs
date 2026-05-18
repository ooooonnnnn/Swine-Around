using System;
using UnityEngine;
public class ItemMagnet : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            FoodScript fsOther = other.GetComponent<FoodScript>();
            if(!fsOther.magnetTarget)
                other.GetComponent<FoodScript>().SetMagnetTarget(Player);
        }
    }
}