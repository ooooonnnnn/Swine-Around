using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class BillboardFaceCamera : MonoBehaviour
{
    [SerializeField, HideInInspector] private Canvas canvas;
    [SerializeField] private Camera targetCamera;

    private void OnValidate()
    {
        canvas = GetComponent<Canvas>();

        if (canvas&& !targetCamera)
        {
            targetCamera = canvas.worldCamera;
            
            if (!targetCamera)
            {
                targetCamera = Camera.main;
            }
        }
    }

    private void Awake()
    {
        canvas = GetComponent<Canvas>();

        if (!targetCamera && canvas)
        {
            targetCamera = canvas.worldCamera;
        }

        if (!targetCamera)
        {
            targetCamera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        if (!targetCamera)
        {
            return;
        }

        transform.rotation = Quaternion.LookRotation(targetCamera.transform.forward);
    }
}