using System;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<Checkpoint> OnCheckpointActivated;
    [SerializeField] private Interactable interactable;
    [SerializeField] private TriggerDetector triggerDetector;
    [SerializeField] private Transform sleepPos;
    public Transform SleepPos => sleepPos;

    private void OnValidate()
    {
        if (!interactable)
            interactable = GetComponentInChildren<Interactable>();
        
        if (!triggerDetector)
            triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    private void OnEnable() => SetActivatable(true);

    private void OnDisable() => SetActivatable(false);

    private void SetActivatable(bool state)
    {
        interactable.isInteractable = state;
        triggerDetector.gameObject.SetActive(state);
    }
    
    public void Activate()
    {
        OnCheckpointActivated.Invoke(this);
    }
}
