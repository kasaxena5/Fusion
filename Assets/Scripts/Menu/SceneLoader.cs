using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject loadingCanvasPrefab;

    [Header("Configs")]
    [SerializeField] private float loadTime = 1;

    public enum SceneState
    {
        Loading,
        Loaded
    }
    [Header("Scene States")]
    public SceneState sceneState = SceneState.Loaded;
    public string currentScene = "MainMenuScene";


    private GameObject loadingCanvas;
    private CanvasGroup canvasGroup;
    private AsyncOperation asyncOperation;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void StartScene()
    {
        StartCoroutine(LoadScene());
    }

    private void SetupLoadingCanvas()
    {
        Instance.sceneState = SceneState.Loading;
        loadingCanvas = Instantiate(loadingCanvasPrefab);
        DontDestroyOnLoad(loadingCanvas);
        canvasGroup = loadingCanvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        loadingCanvas.SetActive(true);
    }

    private void TearDownLoadingCanvas()
    {
        loadingCanvas.SetActive(false);
        Instance.sceneState = SceneState.Loaded;
        Destroy(loadingCanvas);

    }
    IEnumerator LoadScene()
    {
        SetupLoadingCanvas();
        yield return StartCoroutine(fadeLoadingScreen(1, loadTime));
        asyncOperation = SceneManager.LoadSceneAsync(Instance.currentScene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(fadeLoadingScreen(0, loadTime));
        TearDownLoadingCanvas();
    }

    IEnumerator fadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}