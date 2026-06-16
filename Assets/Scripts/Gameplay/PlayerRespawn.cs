using UnityEngine;

namespace Gameplay
{
    public class PlayerRespawn : MonoBehaviour
    {
        private void Start()
        {
            Respawn();
        }

        public void Respawn()
        {
            if (!LevelStateManager.Instance) return;
            if (!LevelStateManager.Instance.HasCheckpoint()) return;

            transform.SetPositionAndRotation(
                LevelStateManager.Instance.GetCheckpointPosition(),
                LevelStateManager.Instance.GetCheckpointRotation()
            );
        }
    }
}