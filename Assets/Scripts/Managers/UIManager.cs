using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] TMP_Text attemptText;
    [SerializeField] IntReference attempts;
    [SerializeField] GameObject nextLevelCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
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
