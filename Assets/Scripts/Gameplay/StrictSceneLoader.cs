using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrictSceneLoader : MonoBehaviour
{
    public void LoadAndDestroyPersistents(SceneAsset sceneAsset)
    {
        var persistentObj = GameObject.Find("~DontDestroyOnLoad");
        if (persistentObj)
        {
            var persistentObjects = persistentObj.scene.GetRootGameObjects();
            
            foreach (var persistentObject in persistentObjects)
            {
                Destroy(persistentObject);
            }
        }
        else
        {
            Debug.LogWarning("No dontdestroyonload scene found");
        }
        
        SceneManager.LoadScene(sceneAsset.name);
    }
}
