using System;
using UnityEngine;

/// <summary>
/// Base class for scripts that control a character controller
/// </summary>
[RequireComponent(typeof(CharacterController)),
RequireComponent(typeof(CharacterMoveMaster)),
RequireComponent(typeof(CharacterGroundNormalDetector))]
public abstract class CharacterControllerBase : MonoBehaviour
{
    [SerializeField, HideInInspector] protected CharacterController characterController;
    [SerializeField, HideInInspector] protected CharacterMoveMaster moveMaster;
    [SerializeField, HideInInspector] protected CharacterGroundNormalDetector groundNormalDetector;

    protected virtual void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
        moveMaster = GetComponent<CharacterMoveMaster>();
        groundNormalDetector = GetComponent<CharacterGroundNormalDetector>();
    }
}
