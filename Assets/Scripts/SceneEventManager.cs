using UnityEngine;
using UnityEngine.Events;  // ���� UnityEvent

public class SceneEventManager : MonoBehaviour
{
    // ʹ�� UnityEvent ������ Action ���͵��¼�
    public UnityEvent OnSceneStart;   // ������ʼʱ�������¼�
    public UnityEvent OnSceneEnd;     // ��������ʱ�������¼�

    private void Start()
    {
        Debug.Log("scene start");
        // ����������ʼʱ��׼������
        OnSceneStart?.Invoke();

    }

    public void EndGame()
    {
        Debug.Log("scene end0");

        // Trigger end game event
        OnSceneEnd?.Invoke();



        // Make sure the EventManager exists
        if (EventManager.Instance != null)
        {
            Debug.Log("EventManager is available. Requesting next scene...");
            EventManager.Instance.RequestNextScene();
        }
        else
        {
            Debug.LogError("EventManager.Instance is null!");
        }
    }

}
