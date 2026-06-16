using System;
using System.Collections;
using System.Threading.Tasks;
using Gameplay;
using Gameplay.Effects;
using Gameplay.Food;
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
            var oldValue = foodEaten;
            foodEaten = value;
            CheckFatnessThreshold();

            var fullnessGained = value - oldValue;

            var fullnessParameters = new FullnessParameters
            {
                currentFullness = foodEaten,
                maxFullness = foodRequiredForFatness * 2,
                fullnessGained = fullnessGained,
            };
            OnFullnessChanged.Invoke(fullnessParameters);
            
            if (fullnessGained > 0) 
                OnFullnessIncreased.Invoke(fullnessParameters);
                
        }
    }
    [SerializeField] private int foodEaten = 0;

    [SerializeField] private float fullnessDecayDelay = 5f;     
    [SerializeField] private float fullnessDecayInterval = 1f;

    [SerializeField, Tooltip("Passed with the current food and \"max\" food")] 
    private UnityEvent<FullnessParameters> OnFullnessChanged;
    [SerializeField, Tooltip("Only when fullness increases")] 
    private UnityEvent<FullnessParameters> OnFullnessIncreased;
    [SerializeField, Tooltip("Passed with the current fatness level")] 
    private UnityEvent<int> OnFatnessLevelChanged;
    
    private Coroutine fullnessDecayCoroutine;
    public FullnessChangedEvent onFullnessChanged;

    [System.Serializable]
    public class FullnessChangedEvent : UnityEvent<int>
    {
    }
    
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
        int previousFatness = fatnessLevel;

        fatnessLevel = foodEaten / foodRequiredForFatness;

        if (previousFatness != fatnessLevel)
        {
            OnFatnessLevelChanged?.Invoke(fatnessLevel);
            onFullnessChanged?.Invoke(fatnessLevel);
        }

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

        while (fatnessLevel >= 0)
        {
            yield return new WaitForSeconds(fullnessDecayInterval);
            DecreaseFatness();
        }

        fullnessDecayCoroutine = null;
    }
}