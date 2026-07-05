using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    public TMP_Text scoreText;

    [Header("Count Animation")]
    public float countDuration = 0.5f;
    public Ease countEase = Ease.OutCubic;

    [Header("Shake Animation")]
    public float shakeDuration = 0.3f;
    public Vector3 shakeStrength = new Vector3(0.2f, 0.2f, 0f);
    public int shakeVibrato = 10;
    public float shakeRandomness = 90f;
    public bool shakeFadeOut = true;

    private int displayedScore;
    private bool hasScore;
    private Vector3 startingScale;
    private Tween countTween;
    private Tween shakeTween;

    private void Awake()
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();
        startingScale = transform.localScale;
    }

    private void OnValidate()
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();
    }

    public void SetScore(int score)
    {
        if (!scoreText) scoreText = GetComponent<TMP_Text>();

        if (!hasScore)
        {
            displayedScore = score;
            scoreText.text = $"{displayedScore}";
            hasScore = true;
            return;
        }

        if (score == displayedScore)
            return;

        bool scoreIncreased = score > displayedScore;

        countTween?.Kill();
        countTween = DOTween.To(
                () => displayedScore,
                value =>
                {
                    displayedScore = value;
                    scoreText.text = $"{displayedScore}";
                },
                score,
                countDuration)
            .SetEase(countEase)
            .SetLink(gameObject);

        if (scoreIncreased)
            PlayShake();
    }

    private void PlayShake()
    {
        shakeTween?.Kill();
        transform.localScale = startingScale;

        shakeTween = transform.DOShakeScale(
                shakeDuration,
                shakeStrength,
                shakeVibrato,
                shakeRandomness,
                shakeFadeOut)
            .SetLink(gameObject);
    }

    private void OnDisable()
    {
        countTween?.Kill();
        shakeTween?.Kill();
        transform.localScale = startingScale;
    }
}
