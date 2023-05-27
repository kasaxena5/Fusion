using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldController : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] FloatReference fieldStrength;
    [SerializeField] float MaxFieldStrength;
    [SerializeField] float fieldIncrement;

    static Rigidbody2D proton;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
            fieldStrength.value = Mathf.Min(MaxFieldStrength, fieldStrength.value + fieldIncrement);
        else if(horizontalInput < 0)
            fieldStrength.value = Mathf.Max(-MaxFieldStrength, fieldStrength.value - fieldIncrement);

    }

    public static bool CheckProton()
    {
        return proton != null;
    }

    bool TrySetProton(Rigidbody2D newProton)
    {
        if (proton != null)
            return false;
        proton = newProton;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D proton))
        {
            if(!TrySetProton(proton))
            {
                Debug.LogError("[MagneticFieldController]: Previous Proton Not Destroyed Properly");
            }
        }
    }

    void ApplyForceField()
    {
        Vector3 v = proton.velocity;
        Vector3 B = new Vector3(0, 0, fieldStrength.value);
        Vector3 force = Vector3.Cross(v, B);
        proton.AddForce(force);

    }

    void FixedUpdate()
    {
        if(proton != null)
            ApplyForceField();
    }
}
