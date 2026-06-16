using Gameplay.Effects;
using Gameplay.Food;
using UnityEngine;

public class ScorePopupSpawner : MonoBehaviour
{
    [SerializeField] private ScorePopup scorePopupPrefab;

    public void Spawn(int score)
    {
        if (score <= 0) return;
        
        ScorePopup newPopup = Instantiate(scorePopupPrefab, transform);
        newPopup.SetScore(score);
    }
    
    public void Spawn(FullnessParameters p) => Spawn(p.fullnessGained * 10);
}
