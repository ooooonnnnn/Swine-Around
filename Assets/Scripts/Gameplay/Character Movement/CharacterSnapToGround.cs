using System;
using UnityEngine;

public class CharacterSnapToGround : CharacterControllerBase
{
    [SerializeField] private float maxSnapDistance;
    [SerializeField] private LayerMask walkableLayers;

    private void FixedUpdate()
    {
        if (Physics.Raycast(
                transform.position,
                -Vector3.up,
                out var hitInfo,
                maxSnapDistance,
                walkableLayers))
        {
            var dist = hitInfo.distance;
            moveMaster.Move(- Vector3.up * dist);
        }
        else
        {
            print("No hit");
        }
    }
}
