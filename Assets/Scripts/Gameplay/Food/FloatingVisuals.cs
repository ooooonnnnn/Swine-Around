using UnityEngine;

public class FloatingVisual : MonoBehaviour
{
    [SerializeField] private float floatAmplitude = 0.2f;
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float rotationSpeed = 90f;

    private Vector3 startLocalPos;
    private float offset;

    private void Awake()
    {
        startLocalPos = transform.localPosition;
        offset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        transform.localPosition = startLocalPos +
                                  Vector3.up * (Mathf.Sin(Time.time * floatSpeed + offset) * floatAmplitude);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}