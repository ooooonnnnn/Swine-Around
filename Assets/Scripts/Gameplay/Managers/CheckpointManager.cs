using System;
using System.Linq;
using UnityEngine;

public class CheckpointManager : PersistentSingleton<CheckpointManager>
{
    [SerializeField] private Checkpoint[] checkpoints;
    [SerializeField] private Checkpoint activeCheckpoint;
    
    private void OnValidate()
    {
        CollectChildrenCheckpoints();
    }

    private void CollectChildrenCheckpoints()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.OnCheckpointActivated.RemoveAllListeners();
            checkpoint.OnCheckpointActivated.AddListener(HandleCheckpointActivated);
        }
    }

    private void HandleCheckpointActivated(Checkpoint checkpoint)
    {
        print($"Checkpoint {checkpoint.name} activated");
        activeCheckpoint = checkpoint;
        activeCheckpoint.enabled = false;
        foreach (var otherCheckpoint in checkpoints.Where(c => c != activeCheckpoint))
        {
            otherCheckpoint.enabled = true;
        }
    }
}
