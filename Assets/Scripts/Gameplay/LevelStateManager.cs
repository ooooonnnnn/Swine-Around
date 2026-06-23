using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelStateManager : PersistentSingleton<LevelStateManager>
    {
        [SerializeField] private Transform startingCheckpoint;
        public Transform currentCheckpoint;

        private bool hasCheckpoint;
        [Header("Level Resetting")]
        [SerializeField] private UnityEvent OnLevelResetCalled;
        [SerializeField] private UnityEvent OnLevelReset;
        [SerializeField] private float resetDelay = 5f;


        protected override void Awake()
        {
            base.Awake();
            if (startingCheckpoint)
            {
                SetCheckpoint(startingCheckpoint);
            }
        }

        [ContextMenu("Restart Level")]
        public void ResetLevel()
        {
            OnLevelResetCalled.Invoke();
            StartCoroutine(DelayAndResetLevel());
        }

        private IEnumerator DelayAndResetLevel()
        {
            yield return new WaitForSeconds(resetDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            OnLevelReset.Invoke();
        }

        public void SetCheckpoint(Transform checkpointTransform)
        {
            if (!checkpointTransform) return;

            currentCheckpoint = checkpointTransform;
            hasCheckpoint = true;
        }

        public Vector3 GetCheckpointPosition() => currentCheckpoint.position;

        public Quaternion GetCheckpointRotation() => currentCheckpoint.rotation;

        public bool HasCheckpoint() => hasCheckpoint;
    }
}