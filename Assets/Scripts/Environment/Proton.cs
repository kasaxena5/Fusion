using UnityEngine;

public class Proton : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Configs")]
    [SerializeField] float maxSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
