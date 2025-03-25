using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action<string> OnSceneLoadRequest;
    public event Action OnGamePause;    // Reintroduced OnGamePause event
    public event Action OnGameResume;   // Reintroduced OnGameResume event

    private int currentSceneIndex = 0;
    private string[] sceneList = { "0 Before", "1 Room","2 Inside Box","3 Room Again" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadNextScene();
    }

    public void RequestNextScene()
    {
        currentSceneIndex++;
        if (currentSceneIndex < sceneList.Length)
        {
            Invoke("LoadNextScene", 2.0f);
        }
        else
        {
            Debug.Log(" ѵ      һ        ");
        }
    }

    private void LoadNextScene()
    {
        if (currentSceneIndex < sceneList.Length)
        {
            string sceneName = sceneList[currentSceneIndex];
            SceneManager.LoadScene(sceneName);
            OnSceneLoadRequest?.Invoke(sceneName);
        }
    }

    // Methods to trigger pause and resume
    public void PauseGame()
    {
        OnGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        OnGameResume?.Invoke();
    }
}
