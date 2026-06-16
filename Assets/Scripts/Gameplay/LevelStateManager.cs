using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelStateManager : MonoBehaviour
    {
        [SerializeField] private Transform startingCheckpoint;

        public static LevelStateManager Instance { get; private set; }

        private Vector3 currentCheckpointPosition;
        private Quaternion currentCheckpointRotation;
        private bool hasCheckpoint;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                if (startingCheckpoint)
                {
                    SetCheckpoint(startingCheckpoint);
                }
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        [ContextMenu("Restart Level")]
        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SetCheckpoint(Transform checkpointTransform)
        {
            if (!checkpointTransform) return;

            currentCheckpointPosition = checkpointTransform.position;
            currentCheckpointRotation = checkpointTransform.rotation;
            hasCheckpoint = true;
        }

        public Vector3 GetCheckpointPosition()
        {
            return currentCheckpointPosition;
        }

        public Quaternion GetCheckpointRotation()
        {
            return currentCheckpointRotation;
        }

        public bool HasCheckpoint()
        {
            return hasCheckpoint;
        }
    }
}