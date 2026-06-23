using DG.Tweening;
using UnityEngine;

public class CheckpointAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private float lingerDuration = 10f;
    
    public void AnimateCheckpointActivation(Checkpoint checkpoint)
    {
        print("animating");
        var sequence = DOTween.Sequence();
        var targetTransform = checkpoint.SleepPos;
        Quaternion targetRotation = targetTransform.rotation *
                                    Quaternion.AngleAxis(Mathf.PI / 2, targetTransform.forward);
        sequence.Append(transform.DOMove(targetTransform.position, animationDuration));
        sequence.Join(transform.DORotateQuaternion(targetRotation, animationDuration));
        
        sequence.Append(transform.DOMove(targetTransform.position, animationDuration));
        sequence.Join(transform.DORotateQuaternion(targetRotation, lingerDuration));
    }
}
