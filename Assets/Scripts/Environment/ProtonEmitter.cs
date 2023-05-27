using UnityEngine;

public class ProtonEmitter : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Proton protonPrefab;
    [SerializeField] Transform protonShooter;

    [Header("Configs")]
    [SerializeField] Vector2 protonInitialVelocity;

    public void OnClick()
    {
        if(!MagneticFieldController.CheckProton())
        {
            Proton proton = Instantiate(protonPrefab, protonShooter.transform.position, Quaternion.identity);
            proton.InitializeVelocity(protonInitialVelocity);
        }
    }

}
