public class PoliceChaseState : IPoliceState
{
    private readonly PoliceAIController _police;

    public PoliceChaseState(PoliceAIController police)
    {
        _police = police;
    }

    public void Enter()
    {
    }

    public void Tick()
    {
        _police.Movement.MoveTo(
            _police.LastKnownPlayerPosition,
            _police.Config.ChaseSpeed
        );

        if (_police.Player) return;

        if (_police.Movement.HasFailedToReachDestination())
        {
            _police.ChangeToSuspicionState();
            return;
        }

        if (!_police.Movement.HasReachedDestination(_police.Config.StopDistance)) return;

        _police.ChangeToSuspicionState();
    }

    public void Exit()
    {
        _police.Movement.Stop();
    }
}
