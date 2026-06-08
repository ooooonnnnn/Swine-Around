using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerRespawn : MonoBehaviour
    {
        private LevelStateManager levelStateManager;
        private void Awake()
        {
            levelStateManager = LevelStateManager.Instance;
            Respawn();
        }

        public void Respawn()
        {
            gameObject.transform.position = LevelStateManager.Instance.GetCheckpoint().position;
        }
    }
}