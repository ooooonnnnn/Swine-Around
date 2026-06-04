using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelStateManager : MonoBehaviour
    {
        public List<string> destroyed = new();
        
        /* ### BLOCKED
         * [SerializeField] private MusicManager musicManager;
         * same for score
         */
        
        [SerializeField] private Transform currentCheckpoint;

        public static LevelStateManager Instance;

        [SerializeField] public GameObject prefabFood;
        [SerializeField] public GameObject prefabDestructable;
        
        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            // GameObject.DontDestroyOnLoad(musicManager);
            // score here
        }
        
        [ContextMenu("Restart Level")]
        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SetCheckpoint(Transform newPos)
        {
            currentCheckpoint = newPos;
        }

        public Transform GetCheckpoint()
        {
            return currentCheckpoint;
        }
    }
}