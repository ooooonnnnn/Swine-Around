using System;
using UnityEngine;

public class CheckpointManager : PersistentSingleton<CheckpointManager>
{
    private void OnValidate()
    {
        CollectChildrenCheckpoints();
    }

    private static void CollectChildrenCheckpoints()
    {
        
    }
}
