using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatsManager : PersistentSingleton<CheatsManager>
{
    public bool isCheatsEnabled;

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
}
