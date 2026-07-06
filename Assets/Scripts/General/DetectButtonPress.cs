using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DetectButtonPress : MonoBehaviour
{
    [SerializeField] private InputActionReference button;
    [SerializeField] private UnityEvent OnButtonPressed;

    private void OnEnable()
    {
        button.action.performed += HandlePressed;
    }

    private void OnDisable()
    {
        button.action.performed -= HandlePressed;
    }

    private void HandlePressed(InputAction.CallbackContext ctx)
    {
        OnButtonPressed.Invoke();
    }
}
