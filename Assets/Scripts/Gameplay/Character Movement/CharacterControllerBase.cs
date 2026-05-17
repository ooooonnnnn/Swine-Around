using System;
using UnityEngine;

/// <summary>
/// Base class for scripts that control a character controller
/// </summary>
[RequireComponent(typeof(CharacterController))]
public abstract class CharacterControllerBase : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;

    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }
}
