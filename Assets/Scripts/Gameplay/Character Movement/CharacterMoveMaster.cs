using System;
using UnityEngine;

public class CharacterMoveMaster : CharacterControllerBase
{
    private Vector3 _totalMove;
    
    public void Move(Vector3 move) => _totalMove += move;
    
    private void FixedUpdate()
    {
        characterController.Move(_totalMove);
        _totalMove = Vector3.zero;
    }
}
