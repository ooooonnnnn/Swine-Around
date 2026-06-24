using System;
using UnityEngine;

public class PersistentUIAnimator : MonoBehaviour
{
    [SerializeField, HideInInspector] private Animator animator;
    [SerializeField] private string sceneTransitionPropertyName;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetSceneTransition(bool transitionOn)
    {
        animator.SetBool(sceneTransitionPropertyName, transitionOn);
    }
}
