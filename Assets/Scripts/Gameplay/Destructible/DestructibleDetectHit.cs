using UnityEngine;
using UnityEngine.Events;

public class DestructibleDetectHit : MonoBehaviour
{
    public UnityEvent OnHit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Attack Collider")) return;
        
        OnHit.Invoke();
        Destroy(gameObject);
    }
}
