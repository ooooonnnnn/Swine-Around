using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelReseting : MonoBehaviour
    {
        [SerializeField] private Vector3 currentPlayerSpawnPosition;
        [SerializeField] private List<GameObject> doNotDestroyObjects;
        // add player here
        
        // singleton
        private static LevelReseting _instance;
        public static LevelReseting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<LevelReseting>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject(typeof(LevelReseting).Name);
                        _instance = obj.AddComponent<LevelReseting>();
                    }
                }

                return _instance;
            }
        }
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as LevelReseting;
                DontDestroyOnLoad(gameObject);
                doNotDestroyObjects = new List<GameObject>();
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        // public bool AddToDoNotDestroy(GameObject other) // call this in Awake of food and destructables 
        // {
        //     if (doNotDestroyObjects.Contains(other))
        //         return false;
        //     doNotDestroyObjects.Add(other);
        //     DontDestroyOnLoad(other);
        //     return true;
        // }

        public void ClearDoNotDestroyList() // call this when changing levels
        {
            foreach (var obj in doNotDestroyObjects)
                Destroy(obj);
            doNotDestroyObjects.Clear();
        }
        
        
        // FOR TESTING
        [ContextMenu("Reload Scene")]
        public void ReloadScene()
        {
            Debug.Log("ReloadingScene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}