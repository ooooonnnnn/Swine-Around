using System;
using UnityEngine;

/// <summary>
/// Base class for scripts that control a character controller
/// </summary>
[RequireComponent(typeof(CharacterController)),
RequireComponent(typeof(CharacterControllerMoveMaster))]
public abstract class CharacterControllerBase : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected CharacterControllerMoveMaster moveMaster;

    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
        moveMaster = GetComponent<CharacterControllerMoveMaster>();
    }
}
