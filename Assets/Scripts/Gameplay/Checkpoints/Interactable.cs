using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public UnityEvent<Interactable> OnInteract;
    [SerializeField] private InputActionReference interactAction;
    [field: SerializeField]
    public bool isInteractable { get; set; }

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
        if (isInteractable)
        {
            OnInteract.Invoke(this);
            print("Interact");
        }
    }
}