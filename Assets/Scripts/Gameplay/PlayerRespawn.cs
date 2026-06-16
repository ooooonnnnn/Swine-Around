using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class PlayerRespawn : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField, HideInInspector] private CharacterController characterController;

        private void OnValidate()
        {
            characterController = playerTransform.GetComponent<CharacterController>();
        }

        private void Start()
        {
            Respawn();
        }

        public void Respawn()
        {
            StartCoroutine(RespawnCor());
        }

        [ContextMenu("Respawn")]
        public IEnumerator RespawnCor()
        {
            if (!LevelStateManager.Instance) yield break;
            if (!LevelStateManager.Instance.HasCheckpoint()) yield break;
            
            characterController.enabled = false;

            var numFramesWait = 1;
            for (int i = 0; i < numFramesWait; i++) yield return null;

            playerTransform.SetPositionAndRotation(
                LevelStateManager.Instance.GetCheckpointPosition(),
                LevelStateManager.Instance.GetCheckpointRotation()
            );
            
            for (int i = 0; i < numFramesWait; i++) yield return null;
            
            characterController.enabled = true;
        }
        
        
    }
}