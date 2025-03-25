using UnityEngine;
using UnityEngine.Events;  // 引入 UnityEvent

public class SceneEventManager0 : MonoBehaviour
{
    // 定义三个状态变量来跟踪事件的完成情况
    private bool event1Completed = false;
    private bool event2Completed = false;
    private bool event3Completed = false;

    // 使用 UnityEvent 来代替 Action 类型的事件
    public UnityEvent OnSceneStart;   // 场景开始时触发的事件
    public UnityEvent OnSceneEnd;     // 场景结束时触发的事件
    public UnityEvent OnAllEventsCompleted;  // 所有事件完成时触发的事件

    private void Start()
    {
        Debug.Log("scene start");
        // 触发场景开始时的准备工作
        OnSceneStart?.Invoke();
    }

    // 用于事件1完成后的回调
    public void OnEvent1Complete()
    {
        event1Completed = true;
        Debug.Log(" event1Completed");
        CheckAndEndGame();
    }

    // 用于事件2完成后的回调
    public void OnEvent2Complete()
    {
        event2Completed = true;
        CheckAndEndGame();
    }

    // 用于事件3完成后的回调
    public void OnEvent3Complete()
    {
        event3Completed = true;
        CheckAndEndGame();
    }

    // 检查所有事件是否都完成，如果完成则触发 EndGame
    private void CheckAndEndGame()
    {
        if (event1Completed && event2Completed && event3Completed)
        {
            OnAllEventsCompleted?.Invoke();  // 所有事件完成时触发 UnityEvent
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
