using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnValidate()
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (!ScoreManager.Instance)
        {
            Debug.LogWarning("ScoreTextUI could not find ScoreManager.");
            return;
        }

        ScoreManager.Instance.AddScoreChangedListener(SetScore);
        SetScore(ScoreManager.Instance.CurrentScore);
    }

    private void OnDestroy()
    {
        if (!ScoreManager.Instance) return;

        ScoreManager.Instance.RemoveScoreChangedListener(SetScore);
    }

    public void SetScore(int score)
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();

        scoreText.text = $"{score}";
    }
}