using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PersistentUIAnimator : MonoBehaviour
{
    [SerializeField, HideInInspector] private Animator animator;
    [FormerlySerializedAs("sceneTransitionPropertyName")] [SerializeField] 
    private string checkpointTransitionPropertyName;
    [SerializeField] private string loseLifeTransitionPropertyName;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetCheckpointTransition(bool transitionOn)
    {
        animator.SetBool(checkpointTransitionPropertyName, transitionOn);
    }

    public void SetLoseLifeTransition(bool transitionOn)
    {
        animator.SetBool(loseLifeTransitionPropertyName, transitionOn);
    }
}
