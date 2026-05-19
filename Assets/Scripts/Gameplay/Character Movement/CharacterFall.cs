using System;
using UnityEngine;

public class CharacterFall : CharacterControllerBase
{
    private float _gravity;

    private void Awake()
    {
        _gravity = Physics.gravity.y;
    }

    private void FixedUpdate()
    {
        var prevVelocity = characterController.velocity.y;
        var newVelocity = prevVelocity;
        
        if (characterController.isGrounded)
        {
            newVelocity = -2f;
        }
        else
        {
            newVelocity += _gravity * Time.fixedDeltaTime;
        }
        
        moveMaster.Move(newVelocity * Time.fixedDeltaTime * Vector3.up);
    }
}
