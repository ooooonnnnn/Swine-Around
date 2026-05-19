using UnityEngine;

public class CharacterGroundNormalDetector : CharacterControllerBase
{
    public Vector3 GroundNormal => _groundNormal;
    private Vector3 _groundNormal;
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Only consider ground hits
        if (hit.point.y >= transform.position.y) return;
        
        _groundNormal = hit.normal;
    }
}
