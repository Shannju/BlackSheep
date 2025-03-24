using UnityEngine;
using UnityEngine.Events;

public class SceneChangeOnCollision : MonoBehaviour
{
    public float delayBeforeSceneChange = 3f; // 延迟时间（秒）
    public UnityEvent onTriggerEnterEvent; // 自定义 UnityEvent

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保物体标签是 "Player"
        {
            Debug.Log("Player triggered! Preparing to change scene.");

            // 在触发时调用 UnityEvent
            if (onTriggerEnterEvent != null)
            {
                onTriggerEnterEvent.Invoke(); // 触发事件
            }
        }
    }

 
}
