using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);  // ����Ϊ��������


    }
    void Start()
    {        // ����¼�������
        EventManager.Instance.OnSceneLoadRequest += LoadScene;
    }

    private void LoadScene(string sceneName)
    {
        // ʹ�ó������������س���
        SceneManager.LoadScene(sceneName);
    }

    void OnDestroy()
    {
        // ȷ���ڶ�������ʱȡ�����ģ���ֹ�ڴ�й©
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnSceneLoadRequest -= LoadScene;
        }
    }
}
