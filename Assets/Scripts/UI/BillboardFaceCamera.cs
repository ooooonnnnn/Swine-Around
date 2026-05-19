using System;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class BillboardFaceCamera : MonoBehaviour
{
    [SerializeField, HideInInspector] private Canvas canvas;
    [SerializeField, HideInInspector] private Camera targetCamera;

    private void OnValidate()
    {
        canvas = GetComponent<Canvas>();
        targetCamera = canvas.worldCamera;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(targetCamera.transform.forward);
    }
}
