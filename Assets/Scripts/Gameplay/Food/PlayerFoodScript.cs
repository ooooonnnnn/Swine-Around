using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerFoodScript : MonoBehaviour
{
    public int fatnessLevel = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            IncreaseFatness();
            Destroy(other.gameObject);
        }
    }

    private void IncreaseFatness()
    {
        if(fatnessLevel == 0)
            _ = StartFatTimer();
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
        gameObject.transform.localScale = Vector3.one * (1 + fatnessLevel * 0.1f);
    }
    
    private async Task StartFatTimer()
    {
        await Task.Delay((int)((fatnessLevel + 1) * 1000f));
        DecreaseFatness();
        if(fatnessLevel > 0)
            await StartFatTimer();
    }
}
