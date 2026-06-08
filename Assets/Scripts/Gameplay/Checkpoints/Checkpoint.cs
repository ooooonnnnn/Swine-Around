using System;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<Checkpoint> OnCheckpointActivated;

    private void OnEnable()
    {
        throw new NotImplementedException();
    }
    
    private void OnDisable()
    {
        throw new NotImplementedException();
    }
}
