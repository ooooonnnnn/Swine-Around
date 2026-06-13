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
    [SerializeField] private int foodEaten = 0;
    
    [SerializeField] private float fullnessDecayDelay = 5f;     
    [SerializeField] private float fullnessDecayInterval = 1f;   
    
    private Coroutine fullnessDecayCoroutine;
    public FullnessChangedEvent onFullnessChanged;

    [System.Serializable]
    public class FullnessChangedEvent : UnityEvent<int>
    {
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
        foodEaten += foodValue;

        CheckFatnessThreshold();

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
            onFullnessChanged?.Invoke(fatnessLevel);
        }

        UpdateScale();
    }
    
    private void DecreaseFatness()
    {
        if (foodEaten > 0)
        {
            foodEaten--;
            CheckFatnessThreshold();
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