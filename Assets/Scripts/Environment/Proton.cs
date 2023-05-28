using UnityEngine;

public class Proton : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Configs")]
    [SerializeField] float maxSpeed;
    [Header("Prefabs")]
    [SerializeField] ParticleSystem explodePrefab;

    protected void DeployParticles()
    {
        ParticleSystem ps = Instantiate(explodePrefab, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(gameObject);
    }

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
        rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Atom")
        {
            DeployParticles();
        }
    }
}
