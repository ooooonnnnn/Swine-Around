using System;
using System.Threading.Tasks;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class PlayerFoodScript : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private int fatnessLevel = 0;
    [SerializeField] private int foodEaten = 0;
    [SerializeField] private int foodRequiredForFatness = 5;
    [SerializeField] private float fatnessToScaleModifier = 0.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            ConsumeFood(other.GetComponent<MagnetizableFood>().foodValue);
            Destroy(other.gameObject);
        }
    }
    private void ConsumeFood(int foodValue)
    {
        foodEaten+= foodValue;
        if(foodEaten >= foodRequiredForFatness) // should i add check for multiple levels per one consumption? (beeg food consumed) 
        {
            foodEaten -= foodRequiredForFatness;
            IncreaseFatness();
        }
    }
    private void IncreaseFatness()
    {
        fatnessLevel++;
        UpdateScale();
    }
    
    private void DecreaseFatness()
    {
        if(fatnessLevel > 0)
            fatnessLevel--;
        UpdateScale();
    }

    private void UpdateScale()
    {
        gameObject.transform.localScale = Vector3.one * (1 + fatnessLevel * fatnessToScaleModifier);
    }
    
}
