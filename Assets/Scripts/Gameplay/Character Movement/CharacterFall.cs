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
        print(prevVelocity);
        var newVelocity = prevVelocity;
        
        if (characterController.isGrounded)
        {
            newVelocity = 0;
        }
        else
        {
            newVelocity += _gravity * Time.fixedDeltaTime;
        }
        
        characterController.Move(newVelocity * Time.fixedDeltaTime * Vector3.up);
    }
}
