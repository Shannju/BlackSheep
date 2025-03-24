using UnityEngine;
using UnityEngine.Events;  // 引入 UnityEvent

public class SceneEventManager : MonoBehaviour
{
    // 使用 UnityEvent 来代替 Action 类型的事件
    public UnityEvent OnSceneStart;   // 场景开始时触发的事件
    public UnityEvent OnSceneEnd;     // 场景结束时触发的事件

    private void Start()
    {
        Debug.Log("scene start");
        // 触发场景开始时的准备工作
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
