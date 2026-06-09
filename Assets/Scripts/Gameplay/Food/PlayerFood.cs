using System;
using System.Collections;
using System.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PlayerFoodScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectToScale;
    
    [SerializeField] private int foodRequiredForFatness = 5;
    [SerializeField] private float fatnessToScaleModifier = 0.1f;
    
    [SerializeField] private int fatnessLevel = 0;

    private int FoodEaten
    {
        get => foodEaten;
        set
        {
            foodEaten = value;
            OnFullnessChanged?.Invoke(foodEaten, foodRequiredForFatness * 2);
            CheckFatnessThreshold();
        }
    }
    [SerializeField] private int foodEaten = 0;

    [SerializeField] private float fullnessDecayDelay = 5f;     
    [SerializeField] private float fullnessDecayInterval = 1f;

    [SerializeField, Tooltip("Passed with the current food and \"max\" food")] 
    private UnityEvent<int, int> OnFullnessChanged;
    
    private Coroutine fullnessDecayCoroutine;

    private void Awake()
    {
        FoodEaten = foodEaten;
    }

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
        FoodEaten += foodValue;

        if (fullnessDecayCoroutine != null)
            StopCoroutine(fullnessDecayCoroutine);

        fullnessDecayCoroutine = StartCoroutine(FullnessDecayRoutine());
    }

    private void CheckFatnessThreshold()
    {
        fatnessLevel = FoodEaten / foodRequiredForFatness;
        UpdateScale();
    }
    
    private void DecreaseFatness()
    {
        if (FoodEaten > 0)
        {
            FoodEaten--;
        }
    }

    private void UpdateScale()
    {
        if(gameObjectToScale)
            gameObjectToScale.transform.localScale = Vector3.one * (1 + fatnessLevel * fatnessToScaleModifier);
    }
    
    private IEnumerator FullnessDecayRoutine()
    {
        yield return new WaitForSeconds(fullnessDecayDelay);

        while (fatnessLevel > 0)
        {
            yield return new WaitForSeconds(fullnessDecayInterval);
            DecreaseFatness();
        }

        fullnessDecayCoroutine = null;
    }
}