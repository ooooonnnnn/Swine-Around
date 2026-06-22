using System;
using Gameplay.Food;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : PersistentSingleton<ScoreManager>
{
    [Serializable]
    public class IntEvent : UnityEvent<int> { }

    [Header("Score")]
    [SerializeField] private int scorePerFullnessPoint = 10;

    [Header("Lives Placeholder")]
    [SerializeField] private int startingLives = 3;

    [Header("Events")]
    [SerializeField] private IntEvent scoreChanged = new();

    public int CurrentScore { get; private set; }
    public int FoodEaten { get; private set; }

    public int LivesLeft { get; private set; }
    public int LivesLost { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != this) return;

        ResetScore();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        FoodEaten = 0;

        LivesLeft = startingLives;
        LivesLost = 0;

        scoreChanged.Invoke(CurrentScore);
    }

    public int AddFood(FullnessParameters fullnessParameters)
    {
        return AddFood(fullnessParameters.fullnessGained);
    }

    public int AddFood(int fullnessAmount)
    {
        if (fullnessAmount <= 0) return 0;

        FoodEaten += fullnessAmount;

        int gainedScore = fullnessAmount * scorePerFullnessPoint;
        CurrentScore += gainedScore;

        scoreChanged.Invoke(CurrentScore);

        return gainedScore;
    }

    public void LoseLife()
    {
        if (LivesLeft <= 0) return;

        LivesLeft--;
        LivesLost++;
    }
}