using System;
using UnityEngine;

[Tooltip("Turns the character towards the direction it is moving")]
public class CharacterTurnToMoveDir : CharacterControllerBase
{
    [SerializeField] private float turnRate;
    private Quaternion _targetRotation = Quaternion.identity;
    
    private void FixedUpdate()
    {
        var velocity = characterController.velocity;
        if (velocity.sqrMagnitude > 0.01f)
        {
            _targetRotation = Quaternion.LookRotation(velocity);
        }
        
        transform.rotation = 
            Quaternion.RotateTowards(
                transform.rotation,
                _targetRotation,
                turnRate * Time.fixedDeltaTime);
    }
}
