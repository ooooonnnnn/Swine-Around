using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PoliceMovement : MonoBehaviour
{
    [SerializeField] private Transform visualRoot;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 targetPosition, float speed)
    {
        Vector3 currentPosition = _rb.position;
        Vector3 direction = targetPosition - currentPosition;

        direction.y = 0f;

        if (direction.magnitude <= 0.05f)
        {
            Stop();
            return;
        }

        Vector3 horizontalVelocity = direction.normalized * speed;

        _rb.linearVelocity = new Vector3(
            horizontalVelocity.x,
            _rb.linearVelocity.y,
            horizontalVelocity.z
        );

        FaceDirection(direction);
    }

    public void Stop()
    {
        _rb.linearVelocity = new Vector3(
            0f,
            _rb.linearVelocity.y,
            0f
        );
    }

    public bool HasReached(Vector3 targetPosition, float stopDistance)
    {
        Vector3 currentPosition = _rb.position;
        Vector3 target = targetPosition;

        currentPosition.y = 0f;
        target.y = 0f;

        float distance = Vector3.Distance(currentPosition, target);

        return distance <= stopDistance;
    }

    private void FaceDirection(Vector3 direction)
    {
        if (visualRoot == null) return;
        if (direction.sqrMagnitude <= 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        visualRoot.rotation = targetRotation;
    }
}
