using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevelManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] TMP_Text totalAttemptsText;
    [SerializeField] IntReference attempts;

    void Start()
    {
        totalAttemptsText.text = "Total Attempts " + attempts.value;
    }

    public void LoadNextLevel(int level)
    {
        if(level == -1)
            SceneLoader.Instance.currentScene = "GameOverMenuScene";
        else
            SceneLoader.Instance.currentScene = "Level" + level + "Scene";
        SceneLoader.Instance.StartScene();
    }
}
