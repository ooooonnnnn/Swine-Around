using Gameplay;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : PersistentSingleton<GameManager>
{
    [FormerlySerializedAs("delayBeforeCheckpointRestart")] 
    [SerializeField] private float delayBeforeRestart;
    [SerializeField] private UnityEvent OnLoseMatch;
    [SerializeField] private UnityEvent OnRestartMatch;
    [SerializeField] private SceneAsset loseScene;
    private bool _canRestart = true;

    /// <summary>
    /// When you get caught and lose a life
    /// </summary>
    public void LoseMatch()
    {
        if (!_canRestart) return;

        if (ScoreManager.Instance)
        {
            if (ScoreManager.Instance.LivesLeft <= 1) //TODO: this should be zero but it doesn't work
            {
                LoseGame();
                return;
            }
        }
        
        OnLoseMatch.Invoke();
        LevelStateManager.Instance.ResetLevel(delayBeforeRestart);
        print("LOSE MATCH");
    }

    /// <summary>
    /// When you run out of lives
    /// </summary>
    public void LoseGame()
    {
        SceneManager.LoadScene(loseScene.name);
    }

    public void WinGame()
    {
        
    }

    public void RestartMatch()
    {
        print("RESTART MATCH Called");
        
        if (!_canRestart) return;
        _canRestart = false;
        SceneManager.sceneLoaded += EnableRestarts;
        
        OnRestartMatch.Invoke();
        LevelStateManager.Instance.ResetLevel(delayBeforeRestart);
    }

    private void EnableRestarts(Scene _, LoadSceneMode __)
    {
        _canRestart = true;
        SceneManager.sceneLoaded -= EnableRestarts;
    }
}
