using System.Collections;
using UnityEngine;

[Tooltip("Makes the character lunge forward for a set duration")]
public class CharacterLunge : CharacterControllerBase
{
    [SerializeField] private float lungeDuration;
    [SerializeField] private float lungeSpeed;
    private Coroutine _lungeRoutine;
    
    public void Lunge() => _lungeRoutine = StartCoroutine(LungeRoutine(Time.time + lungeDuration));
    
    public void StopLunge() => StopCoroutine(_lungeRoutine);

    private IEnumerator LungeRoutine(float endTime)
    {
        while (Time.time < endTime)
        {
            moveMaster.Move(
                lungeSpeed * Time.deltaTime *
                Vector3.ProjectOnPlane(transform.forward, groundNormalDetector.GroundNormal));
            yield return new WaitForFixedUpdate();
        }
    }
}
