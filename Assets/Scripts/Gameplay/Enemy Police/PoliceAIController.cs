using UnityEngine;

public class PoliceAIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PoliceAIConfig config;
    [SerializeField] private PoliceVision vision;
    [SerializeField] private PoliceNavMeshMovement movement;
    [SerializeField] private Transform[] patrolPoints;

    [Header("Debug")]
    [SerializeField] private string currentStateName;
    [SerializeField] private float suspicion;

    private IPoliceState _currentState;

    private PolicePatrolState _patrolState;
    private PoliceSuspicionState _suspicionState;
    private PoliceChaseState _chaseState;

    public PoliceAIConfig Config => config;
    public PoliceVision Vision => vision;
    public PoliceNavMeshMovement Movement => movement;
    public Transform[] PatrolPoints => patrolPoints;

    public Transform Player { get; private set; }
    public Vector3 LastKnownPlayerPosition { get; private set; }

    public float Suspicion => suspicion;

    private void Awake()
    {
        _patrolState = new PolicePatrolState(this);
        _suspicionState = new PoliceSuspicionState(this);
        _chaseState = new PoliceChaseState(this);
    }

    private void Start()
    {
        ChangeState(_patrolState);
    }

    private void Update()
    {
        UpdateVisiblePlayer();
        _currentState?.Tick();
    }

    public void ChangeToPatrolState()
    {
        ChangeState(_patrolState);
    }

    public void ChangeToSuspicionState()
    {
        ChangeState(_suspicionState);
    }

    public void ChangeToChaseState()
    {
        ChangeState(_chaseState);
    }

    public void IncreaseSuspicion()
    {
        suspicion += config.SuspicionIncreaseSpeed * Time.deltaTime;
        suspicion = Mathf.Clamp(suspicion, 0f, config.MaxSuspicion);
    }

    public void DecreaseSuspicion()
    {
        suspicion -= config.SuspicionDecreaseSpeed * Time.deltaTime;
        suspicion = Mathf.Clamp(suspicion, 0f, config.MaxSuspicion);
    }

    public bool IsSuspicionFull()
    {
        return suspicion >= config.MaxSuspicion;
    }

    public bool IsSuspicionEmpty()
    {
        return suspicion <= 0f;
    }

    private void UpdateVisiblePlayer()
    {
        Player = vision.FindVisiblePlayer();

        if (!Player) return;

        LastKnownPlayerPosition = Player.position;
    }

    private void ChangeState(IPoliceState nextState)
    {
        if (_currentState == nextState) return;

        _currentState?.Exit();

        _currentState = nextState;
        currentStateName = nextState.GetType().Name;

        _currentState.Enter();
    }
}
