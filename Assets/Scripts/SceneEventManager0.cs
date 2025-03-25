using UnityEngine;
using UnityEngine.Events;  // ���� UnityEvent

public class SceneEventManager0 : MonoBehaviour
{
    // ��������״̬�����������¼���������
    private bool event1Completed = false;
    private bool event2Completed = false;
    private bool event3Completed = false;

    // ʹ�� UnityEvent ������ Action ���͵��¼�
    public UnityEvent OnSceneStart;   // ������ʼʱ�������¼�
    public UnityEvent OnSceneEnd;     // ��������ʱ�������¼�
    public UnityEvent OnAllEventsCompleted;  // �����¼����ʱ�������¼�

    private void Start()
    {
        Debug.Log("scene start");
        // ����������ʼʱ��׼������
        OnSceneStart?.Invoke();
    }

    // �����¼�1��ɺ�Ļص�
    public void OnEvent1Complete()
    {
        event1Completed = true;
        Debug.Log(" event1Completed");
        CheckAndEndGame();
    }

    // �����¼�2��ɺ�Ļص�
    public void OnEvent2Complete()
    {
        event2Completed = true;
        CheckAndEndGame();
    }

    // �����¼�3��ɺ�Ļص�
    public void OnEvent3Complete()
    {
        event3Completed = true;
        CheckAndEndGame();
    }

    // ��������¼��Ƿ���ɣ��������򴥷� EndGame
    private void CheckAndEndGame()
    {
        if (event1Completed && event2Completed && event3Completed)
        {
            OnAllEventsCompleted?.Invoke();  // �����¼����ʱ���� UnityEvent
            EndGame();
        }
    }

    public void EndGame()
    {
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
