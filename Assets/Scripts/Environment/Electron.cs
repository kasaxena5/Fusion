using UnityEngine;

public class Electron : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private float speed;

    private readonly Vector3 pivotAxis = new(0, 0, 1);

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(transform.parent.position, pivotAxis, speed * Time.deltaTime);
    }
}
