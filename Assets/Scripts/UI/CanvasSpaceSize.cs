using System;
using UnityEngine;

public class CanvasSpaceSize : MonoBehaviour
{
    [SerializeField] private RectTransform parentCanvasRectTransform;
    [SerializeField] private RectTransform rectTransform;
    public float size;

    private void OnValidate()
    {
        GetParentCanvas();
        rectTransform = GetComponent<RectTransform>();
    }

    private void GetParentCanvas()
    {
        var parent = transform.parent;

        while (!parentCanvasRectTransform)
        {
            if (!parent)
            {
                Debug.LogWarning("CanvasSpaceSize: Parent canvas not found.");
                return;
            }
            
            if (parent.GetComponent<Canvas>())
            {
                parentCanvasRectTransform = parent.GetComponent<RectTransform>();
                return;
            }
        }
    }

    private void Update()
    {
        var diagonal = new Vector2(
            parentCanvasRectTransform.rect.width, parentCanvasRectTransform.rect.height)
            .magnitude;
        
        rectTransform.sizeDelta = new Vector2(diagonal, diagonal) * size;
    }
}
