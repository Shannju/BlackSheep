using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    // ���õ� SceneEventManager �ű�
    public SceneEventManager0 sceneEventManager;

    // ���� event1Completed
    public void TriggerEvent1()
    {
        if (sceneEventManager != null)
        {
            sceneEventManager.OnEvent1Complete();
            Debug.Log("Event 1 completed!");
        }
        else
        {
            Debug.LogError("SceneEventManager reference is missing!");
        }
    }

    // ���� event2Completed
    public void TriggerEvent2()
    {
        if (sceneEventManager != null)
        {
            sceneEventManager.OnEvent2Complete();
            Debug.Log("Event 2 completed!");
        }
        else
        {
            Debug.LogError("SceneEventManager reference is missing!");
        }
    }

    // ���� event3Completed
    public void TriggerEvent3()
    {
        if (sceneEventManager != null)
        {
            sceneEventManager.OnEvent3Complete();
            Debug.Log("Event 3 completed!");
        }
        else
        {
            Debug.LogError("SceneEventManager reference is missing!");
        }
    }
}
