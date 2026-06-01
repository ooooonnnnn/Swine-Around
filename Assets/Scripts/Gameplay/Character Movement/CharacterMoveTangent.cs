using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterMoveTangent : CharacterControllerBase
{
    private Vector2 _moveInput;
    [FormerlySerializedAs("speed")] [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
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

    private Vector3 _desiredVelocity;
    private Vector3 _currentVelInMovePlane;

    private void FixedUpdate()
    {
        var desiredDirection = moveRelativeToTransform.TransformDirection(_moveInput.x, 0, _moveInput.y);
        if (characterController.isGrounded)
        {
            desiredDirection = Vector3.ProjectOnPlane(
                desiredDirection, groundNormalDetector.GroundNormal)
                .normalized;
        }

        _desiredVelocity = maxSpeed * desiredDirection;
        _currentVelInMovePlane = Vector3.ProjectOnPlane(
            characterController.velocity, characterController.isGrounded ?
            groundNormalDetector.GroundNormal:
            Vector3.up);
        
        var deltaVel = _desiredVelocity - _currentVelInMovePlane;
        var deltaVAmount = deltaVel.magnitude;
        var accDir = deltaVel.normalized;
        var accAmount = Mathf.Min(acceleration * Time.fixedDeltaTime, deltaVAmount);
        var acc = accDir * accAmount;
        var moveAmount = (_currentVelInMovePlane + acc) * Time.fixedDeltaTime;

        moveMaster.Move(moveAmount);
    }
    
    private void OnDrawGizmos()
    {
        float factor = .5f;
        Gizmos.color = Color.red;
        GizmosExtension.DrawVector(transform.position, _desiredVelocity * factor);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawVector(transform.position, characterController.velocity * factor);
        Gizmos.color = Color.green;
        GizmosExtension.DrawVector(transform.position, _currentVelInMovePlane * factor);
    }
}
