using Gameplay;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : PersistentSingleton<GameManager>
{
    [SerializeField] private float delayBeforeCheckpointRestart;
    [SerializeField] private UnityEvent OnLoseMatch;
    [SerializeField] private UnityEvent OnRestartMatch;
    
    /// <summary>
    /// When you get caught and lose a life
    /// </summary>
    public void LoseMatch()
    {
        OnLoseMatch.Invoke();
        LevelStateManager.Instance.ResetLevel();
        print("LOSE MATCH");
    }

    /// <summary>
    /// When you run out of lives
    /// </summary>
    public void LoseGame()
    {
        
    }

    public void WinGame()
    {
        
    }

    public void RestartMatch()
    {
        OnRestartMatch.Invoke();
        LevelStateManager.Instance.ResetLevel(delayBeforeCheckpointRestart);
    }
}
