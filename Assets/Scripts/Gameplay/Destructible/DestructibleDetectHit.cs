using UnityEngine;
using UnityEngine.Events;

public class DestructibleDetectHit : MonoBehaviour
{
    public UnityEvent OnHit;
    
    private void OnTriggerEnter(Collider other)
    {
        print("HIT");
        OnHit.Invoke();
        Destroy(gameObject);
    }
}
