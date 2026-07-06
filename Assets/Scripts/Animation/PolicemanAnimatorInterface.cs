using System;
using UnityEngine;
using UnityEngine.AI;

public class PolicemanAnimatorInterface : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    private static readonly int WALK_TRIGGER_ID = Animator.StringToHash("WalkTrigger");
    private static readonly int CHASE_TRIGGER_ID = Animator.StringToHash("ChaseTrigger");
    private static readonly int SPEED_PARAMETER_ID = Animator.StringToHash("Speed");

    public void HandleStateChanged(IPoliceState newState)
    {
        var stateType = newState.GetType();
        if (stateType == typeof(PolicePatrolState))
        {
            animator.SetTrigger(WALK_TRIGGER_ID);
            return;
        }

        if (stateType == typeof(PoliceChaseState))
        {
            animator.SetTrigger(CHASE_TRIGGER_ID);
            return;
        }

        if (stateType == typeof(PoliceSuspicionState))
        {
            
        }
        
    }

    private void FixedUpdate()
    {
        var speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat(SPEED_PARAMETER_ID, speed);
    }
}
