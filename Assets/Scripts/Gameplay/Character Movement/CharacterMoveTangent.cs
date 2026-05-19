using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMoveTangent : CharacterControllerBase
{
    private Vector2 _moveInput;
    [SerializeField] private float speed;
    [SerializeField, Tooltip("This moves the character down to keep contact with the ground.")] private float digInPerMove;
    [SerializeField] private Transform moveRelativeToTransform;

    protected override void OnValidate()
    {
        base.OnValidate();
        
        if (!moveRelativeToTransform) moveRelativeToTransform = transform;
    }

    public void TakeMoveInput(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        var rawMoveDirection = moveRelativeToTransform.TransformDirection(_moveInput.x, 0, _moveInput.y);
        if (characterController.isGrounded)
        {
            rawMoveDirection = Vector3.ProjectOnPlane(rawMoveDirection, groundNormalDetector.GroundNormal);
        }

        var digInAmount = characterController.isGrounded ? digInPerMove : 0;
        
        moveMaster.Move(speed * Time.fixedDeltaTime * rawMoveDirection.normalized - digInAmount * Vector3.up);
    }
}
