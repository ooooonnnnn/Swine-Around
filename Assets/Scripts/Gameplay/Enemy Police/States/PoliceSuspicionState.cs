public class PoliceSuspicionState : IPoliceState
{
    private readonly PoliceAIController _police;

    public PoliceSuspicionState(PoliceAIController police)
    {
        _police = police;
    }

    public void Enter()
    {
        _police.Movement.Stop();
    }

    public void Tick()
    {
        if (_police.Player)
        {
            IncreaseSuspicion();
            return;
        }

        DecreaseSuspicion();
    }

    public void Exit()
    {
    }

    private void IncreaseSuspicion()
    {
        _police.IncreaseSuspicion();

        if (!_police.IsSuspicionFull()) return;

        _police.ChangeToChaseState();
    }

    private void DecreaseSuspicion()
    {
        _police.DecreaseSuspicion();

        if (!_police.IsSuspicionEmpty()) return;

        _police.ChangeToPatrolState();
    }
}
