using System;
using UnityEngine;

public class BoarAnimatorInterface : MonoBehaviour
{
    [SerializeField] public CharacterController characterController;
    [SerializeField] public Animator animator;
    private static readonly int WALK_BOOL_ID = Animator.StringToHash("Walk");
    private static readonly int RAM_TRIGGER_ID = Animator.StringToHash("Ram");

    private void Update()
    {
        if (characterController.velocity != Vector3.zero)
            animator.SetBool(WALK_BOOL_ID, true);
        else    
            animator.SetBool(WALK_BOOL_ID, false);
    }

    public void RamTrigger()
    {
        animator.SetTrigger(RAM_TRIGGER_ID);
    }
}
