using UnityEngine;

public class DestroyAfterSomeTime : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] float duration;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}