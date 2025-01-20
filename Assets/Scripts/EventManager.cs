using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action<string> OnSceneLoadRequest;
    public event Action OnGamePause;
    public event Action OnGameResume;

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
        SceneManager.LoadScene("StartMenu");
    }


    public void RequestSceneLoad(string sceneName)
    {
        OnSceneLoadRequest?.Invoke(sceneName);
    }

    public void PauseGame()
    {
        OnGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        OnGameResume?.Invoke();
    }
}
