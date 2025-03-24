using UnityEngine;
using UnityEngine.Events;

public class SceneChangeOnCollision : MonoBehaviour
{
    public float delayBeforeSceneChange = 3f; // �ӳ�ʱ�䣨�룩
    public UnityEvent onTriggerEnterEvent; // �Զ��� UnityEvent

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ�������ǩ�� "Player"
        {
            Debug.Log("Player triggered! Preparing to change scene.");

            // �ڴ���ʱ���� UnityEvent
            if (onTriggerEnterEvent != null)
            {
                onTriggerEnterEvent.Invoke(); // �����¼�
            }
        }
    }

 
}
