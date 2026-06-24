using System;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointManagerProxy : MonoBehaviour
{
    public UnityEvent<Checkpoint> OnCheckpointActivated;
    
    private void Start()
    {
        CheckpointManager.Instance.OnCheckpointActivated.AddListener(OnCheckpointActivated.Invoke);
    }
}
