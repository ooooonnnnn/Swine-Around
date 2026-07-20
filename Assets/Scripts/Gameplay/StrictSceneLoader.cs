using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrictSceneLoader : MonoBehaviour
{
    public void LoadAndDestroyPersistents(string sceneName)
    {
        GameObject dummyDDOL = new GameObject("");
        DontDestroyOnLoad(dummyDDOL);
        var scene = dummyDDOL.scene;
        var persistentObjects = scene.GetRootGameObjects();
        
        foreach (var persistentObject in persistentObjects)
        {
            Destroy(persistentObject);
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
