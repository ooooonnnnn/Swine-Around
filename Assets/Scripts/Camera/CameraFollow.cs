using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Follow Settings")]
    [SerializeField] private bool followY = false;
    [SerializeField] private float smoothTime = 0.2f;

    private Vector3 offset;
    private Vector3 currentVelocity;

    private void Start()
    {
        if (!player)
        {
            Debug.LogError("CameraFollow: Player is not assigned.");
            enabled = false;
            return;
        }

        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = transform.position;

        targetPosition.x = player.position.x + offset.x;
        targetPosition.z = player.position.z + offset.z;

        if (followY)
        {
            targetPosition.y = player.position.y + offset.y;
        }

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref currentVelocity,
            smoothTime
        );
    }
}
