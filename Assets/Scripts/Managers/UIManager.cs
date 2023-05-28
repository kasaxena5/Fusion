using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] TMP_Text attemptText;
    [SerializeField] IntReference attempts;
    [SerializeField] FloatReference fieldStrength;
    [SerializeField] GameObject nextLevelCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        fieldStrength.value = 0;
        attempts.value = 1;
    }

    public void ResetStrength()
    {
        fieldStrength.value = 0;
    }

    void Update()
    {
        attemptText.text = "Attempt " + attempts.value;
    }

    public void LevelCompleted()
    {
        nextLevelCanvas.SetActive(true);
    }


}
