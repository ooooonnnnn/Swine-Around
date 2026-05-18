using System;
using UnityEngine;

public class GizmoWaypoint : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
