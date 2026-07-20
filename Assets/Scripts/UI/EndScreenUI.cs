using System;
using UnityEngine;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private NumberDisplay scoreDisplay, foodDisplay;

    private void Start()
    {
        if (!ScoreManager.Instance)
        {
            Debug.LogWarning("No score manager to take values from");
            return;
        }
        
        scoreDisplay.SetNumber(ScoreManager.Instance.CurrentScore);
        foodDisplay.SetNumber(ScoreManager.Instance.FoodEaten);
    }
}
