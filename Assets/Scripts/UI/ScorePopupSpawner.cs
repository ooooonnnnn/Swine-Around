using Gameplay.Effects;
using UnityEngine;

public class ScorePopupSpawner : MonoBehaviour
{
    [SerializeField] private ScorePopup scorePopupPrefab;

    public void Spawn(int score)
    {
        ScorePopup newPopup = Instantiate(scorePopupPrefab, transform);
        newPopup.score = score;
    }
    
    public void Spawn(int score, int _) => Spawn(score);
}
