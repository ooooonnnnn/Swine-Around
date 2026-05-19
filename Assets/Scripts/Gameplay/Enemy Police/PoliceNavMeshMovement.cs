using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PoliceNavMeshMovement : MonoBehaviour
{
    [SerializeField] private Transform visualRoot;
    [SerializeField] private float navMeshSampleRadius = 2f;

    private NavMeshAgent _agent;

    public bool HasValidPath => _agent.hasPath && _agent.pathStatus == NavMeshPathStatus.PathComplete;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FaceMovementDirection();
    }

    public void MoveTo(Vector3 targetPosition, float speed)
    {
        if (!_agent.enabled) return;
        if (!_agent.isOnNavMesh) return;

        if (!TryGetNavMeshPosition(targetPosition, out Vector3 navMeshPosition)) return;

        _agent.isStopped = false;
        _agent.speed = speed;
        _agent.SetDestination(navMeshPosition);
    }

    public void Stop()
    {
        if (!_agent.enabled) return;
        if (!_agent.isOnNavMesh) return;

        _agent.isStopped = true;
        _agent.ResetPath();
    }

    public bool HasReachedDestination(float stopDistance)
    {
        if (!_agent.enabled) return false;
        if (!_agent.isOnNavMesh) return false;
        if (_agent.pathPending) return false;

        if (!_agent.hasPath) return true;

        return _agent.remainingDistance <= stopDistance;
    }

    public bool HasFailedToReachDestination()
    {
        if (!_agent.enabled) return true;
        if (!_agent.isOnNavMesh) return true;
        if (_agent.pathPending) return false;

        return _agent.pathStatus == NavMeshPathStatus.PathInvalid;
    }

    private bool TryGetNavMeshPosition(Vector3 position, out Vector3 navMeshPosition)
    {
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, navMeshSampleRadius, NavMesh.AllAreas))
        {
            navMeshPosition = hit.position;
            return true;
        }

        navMeshPosition = position;
        return false;
    }

    private void FaceMovementDirection()
    {
        if (!visualRoot) return;
        if (!_agent.enabled) return;
        if (!_agent.isOnNavMesh) return;

        Vector3 velocity = _agent.velocity;
        velocity.y = 0f;

        if (velocity.sqrMagnitude <= 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(
            velocity.normalized,
            Vector3.up
        );

        visualRoot.rotation = targetRotation;
    }
}
