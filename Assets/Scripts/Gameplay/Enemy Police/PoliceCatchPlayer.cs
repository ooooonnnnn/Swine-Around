using Gameplay;
using UnityEngine;
using UnityEngine.Events;

public class PoliceCatchPlayer : MonoBehaviour
{
    [SerializeField] private PoliceAIController police;
    [SerializeField] private UnityEvent OnPlayerCaught;

    private bool _hasCaughtPlayer;

    private void Update()
    {
        if (_hasCaughtPlayer) return;
        if (!police.Player) return;

        float distance = Vector3.Distance(
            transform.position,
            police.Player.position
        );

        if (distance > police.Config.CatchDistance) return;

        CatchPlayer();
    }

    private void CatchPlayer()
    {
        _hasCaughtPlayer = true;

        police.StopAI();

        OnPlayerCaught.Invoke();
        
        // if (LevelStateManager.Instance) LevelStateManager.Instance.ResetLevel();
        GameManager.Instance.LoseMatch();

        if (ScoreManager.Instance)
        {
            ScoreManager.Instance.LoseLife();
        }
    }
}
