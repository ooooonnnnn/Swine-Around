using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private float lingerDuration = 10f;
    [SerializeField] private PlayerInput playerInput;
    
    public void AnimateCheckpointActivation(Checkpoint checkpoint)
    {
        print("animating");
        var sequence = DOTween.Sequence();
        var targetTransform = checkpoint.SleepPos;
        Quaternion targetRotation = targetTransform.rotation *
                                    Quaternion.AngleAxis(Mathf.PI / 2, targetTransform.forward);
        
        if (playerInput) playerInput.actions.FindActionMap("Player", true).Disable();
        
        sequence.Append(transform.DOMove(targetTransform.position, animationDuration));
        sequence.Join(transform.DORotateQuaternion(targetRotation, animationDuration));
        
        sequence.Append(transform.DOMove(targetTransform.position, animationDuration));
        sequence.Join(transform.DORotateQuaternion(targetRotation, lingerDuration));
        sequence.AppendCallback(() => 
        {
        if (playerInput) playerInput.actions.FindActionMap("Player", true).Enable();
        });
    }
}
