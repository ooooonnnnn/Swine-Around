using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnValidate()
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();
    }

    public void SetScore(int score)
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();

        scoreText.text = $"{score}";
    }
}