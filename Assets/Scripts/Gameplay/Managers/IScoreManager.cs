using Gameplay.Food;
using UnityEngine;

public interface IScoreManager
{
    public int CurrentScore { get; }
    public int FoodEaten { get; }

    public int LivesLeft { get; }
    public int LivesLost { get; }

    public int AddFood(FullnessParameters fullnessParameters);

    public void LoseLife();
}
