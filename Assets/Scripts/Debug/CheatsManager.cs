using System.Collections;
using System.Linq;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatsManager : PersistentSingleton<CheatsManager>
{
    [ContextMenu("Restart Completely")]
    public void RestartCompletely() => StartCoroutine(RestartCompletelyCor());
    
    private IEnumerator RestartCompletelyCor()
    {
        var allObjects = FindObjectsByType<GameObject>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var obj in allObjects)
        {
            if (obj != this.gameObject)
                Destroy(obj);
        }
        
        yield return null;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject);
    }

    [ContextMenu("Restart From Checkpoint")]
    public void RestartFromCheckpoint()
    {
        if (!LevelStateManager.Instance) return;
        
        LevelStateManager.Instance.ResetLevel();
    }
}
