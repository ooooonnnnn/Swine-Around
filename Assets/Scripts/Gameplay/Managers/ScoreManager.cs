using System;
using Gameplay.Food;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : PersistentSingleton<ScoreManager>, IScoreManager
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

    private void ResetScore()
    {
        CurrentScore = 0;
        FoodEaten = 0;

        LivesLeft = startingLives;
        LivesLost = 0;

        scoreChanged.Invoke(CurrentScore);
    }

    public void AddFood(FullnessParameters fullnessParameters)
    {
        FoodEaten += fullnessParameters.fullnessGained;

        int gainedScore = GetScoreFromFood(fullnessParameters);
        CurrentScore += gainedScore;

        scoreChanged.Invoke(CurrentScore);
    }

    public void LoseLife()
    {
        if (LivesLeft <= 0) return;

        LivesLeft--;
        LivesLost++;
    }

    public int GetScoreFromFood(FullnessParameters parameters)
    {
        var score = parameters.fullnessGained > 0 ? parameters.fullnessGained * scorePerFullnessPoint : 0;
        return score;
    }
}