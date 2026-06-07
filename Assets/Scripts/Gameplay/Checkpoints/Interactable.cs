using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent<Interactable> OnInteract;
    [SerializeField] private InputActionReference interactAction;
    public bool isInteractable;

    private void OnEnable()
    {
        interactAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        interactAction.action.performed -= Interact;
    }
    
    public void Interact(InputAction.CallbackContext ctx) => Interact();

    public void Interact()
    {
        if (isInteractable) OnInteract.Invoke(this);
    }
}