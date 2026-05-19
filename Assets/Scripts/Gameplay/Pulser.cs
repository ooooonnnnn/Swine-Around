using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Tooltip("Outputs a boolean pulse when triggered")]
public class Pulser : MonoBehaviour
{
    [SerializeField] private float pulseDuration;
    public UnityEvent OnPulseStart;
    public UnityEvent OnPulseEnd;
    private float _timer;
    private bool _pulseActive;

    public void Pulse()
    {
        OnPulseStart.Invoke();
        _pulseActive = true;
        _timer = 0;
    }

    public void Pulse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) Pulse();
    }

    private void Update()
    {
        if (!_pulseActive) return;
        
        _timer += Time.deltaTime;

        if (_timer >= pulseDuration)
        {
            _pulseActive = false;
            OnPulseEnd.Invoke();
        }
    }
}
