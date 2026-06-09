using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorFromInt : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color[] colors;
    
    public void SetColor(int index)
    {
        if (!image) return;
        if (colors.Length == 0) return;
        image.color = colors[Math.Min(index, colors.Length - 1)];
    }
}
