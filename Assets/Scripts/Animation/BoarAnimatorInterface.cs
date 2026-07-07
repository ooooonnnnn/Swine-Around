using System;
using UnityEngine;

public class BoarAnimatorInterface : MonoBehaviour
{
    [SerializeField] public CharacterController characterController;
    [SerializeField] public Animator animator;
    private static readonly int WALK_TRIGGER_ID = Animator.StringToHash("MoveTrigger");
    private static readonly int IDLE_TRIGGER_ID = Animator.StringToHash("IdleTrigger");

    private void Update()
    {
        if (characterController.velocity != Vector3.zero)
            animator.SetTrigger(WALK_TRIGGER_ID);
        else    
            animator.SetTrigger(IDLE_TRIGGER_ID);
    }
}
