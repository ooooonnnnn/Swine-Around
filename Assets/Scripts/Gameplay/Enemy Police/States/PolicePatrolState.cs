using UnityEngine;

public class PolicePatrolState: IPoliceState
{
    private readonly PoliceAIController _police;

    private int _currentPatrolIndex;

    public PolicePatrolState(PoliceAIController police)
    {
        _police = police;
    }

    public void Enter()
    {
    }

    public void Tick()
    {
        if (_police.Player)
        {
            _police.ChangeToSuspicionState();
            return;
        }

        Patrol();
    }

    public void Exit()
    {
    }

    private void Patrol()
    {
        if (_police.PatrolPoints.Length == 0)
        {
            _police.Movement.Stop();
            return;
        }

        Transform targetPoint = _police.PatrolPoints[_currentPatrolIndex];

        _police.Movement.MoveTo(
            targetPoint.position,
            _police.Config.PatrolSpeed
        );

        if (!_police.Movement.HasReached(
                targetPoint.position,
                _police.Config.StopDistance))
        {
            return;
        }

        _currentPatrolIndex++;
        _currentPatrolIndex %= _police.PatrolPoints.Length;
    }
}
