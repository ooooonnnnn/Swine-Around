using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Pauser : MonoBehaviour
{
    [SerializeField] private UnityEvent OnGamePaused;
    [SerializeField] private UnityEvent OnGameUnpaused;
    [SerializeField] private PlayerInput playerInput;
    private bool _isPaused = false;
    
    public void TogglePause()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            OnGamePaused.Invoke();
            Time.timeScale = 0.0f;
        }
        else
        {
            OnGameUnpaused.Invoke();
            Time.timeScale = 1.0f;
        }
    }
}