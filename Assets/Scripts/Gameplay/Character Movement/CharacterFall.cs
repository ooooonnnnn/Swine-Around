using System;
using UnityEngine;

public class CharacterFall : CharacterControllerBase
{
    private void FixedUpdate()
    {
        var prevVelocity = characterController.velocity.y;
        var newVelocity = prevVelocity;
        
        newVelocity += Physics.gravity.y * Time.fixedDeltaTime;
        
        moveMaster.Move(newVelocity * Time.fixedDeltaTime * Vector3.up);
    }
}
