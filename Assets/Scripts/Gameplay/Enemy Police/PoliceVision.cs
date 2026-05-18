using UnityEngine;

public class PoliceVision : MonoBehaviour
{
    [SerializeField] private PoliceAIConfig config;
    [SerializeField] private Transform visionOrigin;
    [SerializeField] private Transform facingRoot;

    public Transform FindVisiblePlayer()
    {
        Collider[] playerColliders = Physics.OverlapSphere(
            visionOrigin.position,
            config.VisionRadius,
            config.PlayerLayer
        );

        if (playerColliders.Length == 0) return null;

        Transform player = playerColliders[0].transform;

        if (!IsInsideVisionCone(player)) return null;
        if (HasObstacleBetween(player)) return null;

        return player;
    }

    private bool IsInsideVisionCone(Transform target)
    {
        Vector3 directionToTarget = target.position - visionOrigin.position;
        directionToTarget.y = 0f;

        Vector3 forwardDirection = facingRoot.forward;
        forwardDirection.y = 0f;

        if (directionToTarget.sqrMagnitude <= 0.001f) return true;

        float angle = Vector3.Angle(forwardDirection, directionToTarget);

        return angle <= config.VisionAngle * 0.5f;
    }

    private bool HasObstacleBetween(Transform target)
    {
        Vector3 origin = visionOrigin.position;
        Vector3 direction = target.position - origin;
        float distance = direction.magnitude;

        bool hasObstacle = Physics.Raycast(
            origin,
            direction.normalized,
            distance,
            config.ObstacleLayer
        );

        return hasObstacle;
    }

    private void OnDrawGizmosSelected()
    {
        if (config == null) return;
        if (visionOrigin == null) return;
        if (facingRoot == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(visionOrigin.position, config.VisionRadius);

        Vector3 forwardDirection = facingRoot.forward;

        Vector3 leftDirection = Quaternion.Euler(
            0f,
            -config.VisionAngle * 0.5f,
            0f
        ) * forwardDirection;

        Vector3 rightDirection = Quaternion.Euler(
            0f,
            config.VisionAngle * 0.5f,
            0f
        ) * forwardDirection;

        Gizmos.DrawLine(
            visionOrigin.position,
            visionOrigin.position + leftDirection * config.VisionRadius
        );

        Gizmos.DrawLine(
            visionOrigin.position,
            visionOrigin.position + rightDirection * config.VisionRadius
        );
    }
}
