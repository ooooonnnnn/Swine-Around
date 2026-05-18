using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActivateWithCooldown : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float _cooldownTimer;
    public UnityEvent OnActivate;
    
    public void Activate()
    {
        if (_cooldownTimer > 0) return;
        
        OnActivate.Invoke();
        
        _cooldownTimer = cooldown;
    }

    public void Activate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) Activate();
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;
    }
}
