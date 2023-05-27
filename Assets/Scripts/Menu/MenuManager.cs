using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.Instance.currentScene = "InstructionScene";
        SceneLoader.Instance.StartScene();
    }

    public void ContinueToGame()
    {
        SceneLoader.Instance.currentScene = "Level1Scene";
        SceneLoader.Instance.StartScene();
    }

    public void ReturnToMenu()
    {
        SceneLoader.Instance.currentScene = "MainMenuScene";
        SceneLoader.Instance.StartScene();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}