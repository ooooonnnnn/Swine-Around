using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public Transform parentOptional;
    
    public void Instantiate()
    {
        print("Instantiating");
        Instantiate(prefab, transform.position, transform.rotation, parentOptional);
    }
}
