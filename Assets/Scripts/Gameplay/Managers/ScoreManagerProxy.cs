using Gameplay.Food;
using UnityEngine;

public class ScoreManagerProxy : Singleton<ScoreManagerProxy>, IScoreManager
{
    public int CurrentScore => ScoreManager.Instance.CurrentScore;
    public int FoodEaten => ScoreManager.Instance.FoodEaten;
    public int LivesLeft => ScoreManager.Instance.LivesLeft;
    public int LivesLost => ScoreManager.Instance.LivesLost;
    
    public void AddFood(FullnessParameters fullnessParameters) => ScoreManager.Instance.AddFood(fullnessParameters);

    public void LoseLife() => ScoreManager.Instance.LoseLife();
}
