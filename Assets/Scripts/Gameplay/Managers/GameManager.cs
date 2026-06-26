using Gameplay;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    [SerializeField] private float delayBeforeCheckpointRestart;
    [SerializeField] private UnityEvent OnLoseMatch;
    [SerializeField] private UnityEvent OnRestartMatch;
    private bool _canRestart = true;

    /// <summary>
    /// When you get caught and lose a life
    /// </summary>
    public void LoseMatch()
    {
        if (!_canRestart) return;
        
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
        if (!_canRestart) return;
        _canRestart = false;
        SceneManager.sceneLoaded += EnableRestarts;
        
        OnRestartMatch.Invoke();
        LevelStateManager.Instance.ResetLevel(delayBeforeCheckpointRestart);
    }

    private void EnableRestarts(Scene _, LoadSceneMode __)
    {
        _canRestart = true;
        SceneManager.sceneLoaded -= EnableRestarts;
    }
}
