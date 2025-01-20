using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);  // 设置为不被销毁


    }
    void Start()
    {        // 添加事件监听器
        EventManager.Instance.OnSceneLoadRequest += LoadScene;
    }

    private void LoadScene(string sceneName)
    {
        // 使用场景管理器加载场景
        SceneManager.LoadScene(sceneName);
    }

    void OnDestroy()
    {
        // 确保在对象销毁时取消订阅，防止内存泄漏
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnSceneLoadRequest -= LoadScene;
        }
    }
}
