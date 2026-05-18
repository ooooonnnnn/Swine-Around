using System;
using JetBrains.Annotations;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float acceleration = 25f;
    [SerializeField] private float maxSpeed = 20f;

    private Vector3 velocity = Vector3.zero;
    
    [CanBeNull, HideInInspector] public GameObject magnetTarget;
    public void SetMagnetTarget(GameObject other)
    {
        magnetTarget = other;
    }

    private void Update()
    {
        if (magnetTarget)
        {
            Vector3 direction = (magnetTarget.transform.position - transform.position).normalized;
            velocity += direction * (acceleration * Time.deltaTime);
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity * Time.deltaTime;
        }
    }
}
