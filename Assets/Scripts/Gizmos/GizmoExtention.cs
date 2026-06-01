using UnityEngine;

public static class GizmosExtension
{
    public static void DrawVector(Vector3 origin, Vector3 vector, float endCapRadius = 0.1f)
    {
        Gizmos.DrawLine(origin, origin + vector);
        Gizmos.DrawSphere(origin + vector, endCapRadius);
    }
}
