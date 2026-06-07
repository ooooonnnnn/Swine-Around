using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private string interactorTag;
    [SerializeField] private UnityEvent OnInteractorEnter;
    [SerializeField] private UnityEvent OnInteractorExit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interactorTag)) OnInteractorEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interactorTag)) OnInteractorExit.Invoke();
    }
}
