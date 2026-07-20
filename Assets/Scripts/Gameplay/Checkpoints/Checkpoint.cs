using System;
using General;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<Checkpoint> OnCheckpointActivated;
    [SerializeField] private Interactable interactable;
    [SerializeField] private TriggerDetector triggerDetector;
    [SerializeField] private Transform sleepPos;
    [SerializeField] private SetActiveObjects modelSwitcher;
    public Transform SleepPos => sleepPos;

    private void OnValidate()
    {
        if (!interactable)
            interactable = GetComponentInChildren<Interactable>();
        
        if (!triggerDetector)
            triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    private void OnEnable()
    {
        SetActivatable(true);
        modelSwitcher.SetActives(false);
    }

    private void OnDisable()
    {
        SetActivatable(false);
        modelSwitcher.SetActives(true);
    }

    private void SetActivatable(bool state)
    {
        interactable.isInteractable = state;
        triggerDetector.gameObject.SetActive(state);
    }
    
    public void Activate()
    {
        print($"Checkpoint {name} activated");
        OnCheckpointActivated.Invoke(this);
    }
}
