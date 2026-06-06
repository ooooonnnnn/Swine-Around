using System;
using JetBrains.Annotations;
using UnityEngine;

public class MagnetizableFood : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float acceleration = 25f;
    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] public int foodValue = 1;
    
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
            float currentSpeed = velocity.magnitude;
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            velocity = direction * currentSpeed;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
