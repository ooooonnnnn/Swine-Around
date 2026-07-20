using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField] private string format;
    [SerializeField] private float number;
    [SerializeField] private TMP_Text numberText;

    [Header("Count Animation")]
    public float countDuration = 4.0f;
    public Ease countEase = Ease.OutCubic;

    private float displayedNumber;
    private bool hasNumber;
    private Vector3 startingScale;
    private Tween countTween;
    private Tween shakeTween;

    private void Start()
    {
        SetNumber(number);
    }

    public void SetNumber(float number)
    {
        if (!hasNumber)
        {
            displayedNumber = number;
            numberText.text = $"{displayedNumber}";
            hasNumber = true;
            return;
        }

        if (number == displayedNumber)
            return;


        countTween?.Kill();
        countTween = DOTween.To(
                () => displayedNumber,
                value =>
                {
                    displayedNumber = value;
                    numberText.text = $"{displayedNumber}";
                },
                number,
                countDuration)
            .SetEase(countEase)
            .SetLink(gameObject);
    }
}
