using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFillFromValue : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float fillTweenDuration;

    public void SetFillAmount(float value)
    {
        if (!image) return;
        value = Mathf.Clamp01(value);
        
        image.DOFillAmount(value, fillTweenDuration);
    }

    public void SetFillAmount(int value, int maxValue) => SetFillAmount(value / (float)maxValue);
}
