using System;
using UnityEngine;

[Tooltip("Turns the character towards the direction it is moving")]
public class CharacterTurnToMoveDir : CharacterControllerBase
{
    [SerializeField] private float turnRate;
    [SerializeField] private float pitchRate;
    [SerializeField] private Transform pitchRecipient;
    private Quaternion _selfRotation = Quaternion.identity;
    
    private void FixedUpdate()
    {
        // set self rotation
        var velocity = characterController.velocity;
        var lateralVelocity = new Vector3(velocity.x, 0, velocity.z);
        var isMoving = velocity.sqrMagnitude > 0.01f;
        if (isMoving)
        {
            _selfRotation = Quaternion.LookRotation(lateralVelocity, Vector3.up);
        }
        
        transform.rotation = 
            Quaternion.RotateTowards(
                transform.rotation,
                _selfRotation,
                turnRate * Time.fixedDeltaTime);
        
        if (!pitchRecipient) return;
        
        // control pitch of pitch recipient
        var pitchVector = isMoving ? lateralVelocity.magnitude * Vector3.forward + velocity.y * Vector3.up
            : Vector3.forward;
        
        //print(pitchVector);
        
        var pitchRotation = Quaternion.LookRotation(pitchVector, Vector3.up);
        pitchRecipient.localRotation = Quaternion.RotateTowards(
            pitchRecipient.localRotation,
            pitchRotation,
            pitchRate * Time.fixedDeltaTime);
    }
}
