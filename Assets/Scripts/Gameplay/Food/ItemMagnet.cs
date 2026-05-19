using System;
using UnityEngine;
public class ItemMagnet : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            MagnetizableFood fsOther = other.GetComponent<MagnetizableFood>();
            if(!fsOther.magnetTarget)
                other.GetComponent<MagnetizableFood>().SetMagnetTarget(Player);
        }
    }
}