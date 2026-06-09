using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelStateManager : MonoBehaviour
    {
        /* ### BLOCKED
         * [SerializeField] private MusicManager musicManager;
         * same for score
         */
        
        [SerializeField] private Transform currentCheckpoint;

        public static LevelStateManager Instance;
        
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

            SetCheckpoint(currentCheckpoint);
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
            currentCheckpoint.transform.SetParent(null);
            currentCheckpoint = newPos;
            currentCheckpoint.transform.SetParent(gameObject.transform);
        }

        public Transform GetCheckpoint()
        {
            return currentCheckpoint;
        }
    }
}