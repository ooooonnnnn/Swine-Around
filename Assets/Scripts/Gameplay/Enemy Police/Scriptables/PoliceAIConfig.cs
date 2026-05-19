using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Police/Police AI Config")]
public class PoliceAIConfig : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float stopDistance = 0.2f;

    [Header("Vision")]
    [SerializeField] private float visionRadius = 5f;
    [SerializeField] private float visionAngle = 70f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Suspicion")]
    [SerializeField] private float suspicionIncreaseSpeed = 30f;
    [SerializeField] private float suspicionDecreaseSpeed = 20f;
    [SerializeField] private float maxSuspicion = 100f;

    [Header("Catch")]
    [SerializeField] private float catchDistance = 0.5f;

    public float PatrolSpeed => patrolSpeed;
    public float ChaseSpeed => chaseSpeed;
    public float StopDistance => stopDistance;

    public float VisionRadius => visionRadius;
    public float VisionAngle => visionAngle;
    public LayerMask PlayerLayer => playerLayer;
    public LayerMask ObstacleLayer => obstacleLayer;

    public float SuspicionIncreaseSpeed => suspicionIncreaseSpeed;
    public float SuspicionDecreaseSpeed => suspicionDecreaseSpeed;
    public float MaxSuspicion => maxSuspicion;

    public float CatchDistance => catchDistance;
}