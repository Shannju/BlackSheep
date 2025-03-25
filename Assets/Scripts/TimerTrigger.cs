using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerTrigger : MonoBehaviour
{
    // ��ʱ��
    private float timer = 0f;
    // ���ʱ�䣨100�룩
    public float maxTime = 100f;

    // ����Unity�¼��б�
    public UnityEvent onTimerComplete;

    void Update()
    {
        // ��ʱ������
        if (timer < maxTime)
        {
            timer += Time.deltaTime;
        }

        // �����ʱ���ﵽ���ʱ�䣬�����¼�
        if (timer >= maxTime)
        {
            if (onTimerComplete != null)
            {
                onTimerComplete.Invoke();
            }
            // ���ü�ʱ��������������ѡ�����ٽű�����������
            timer = 0f;
        }
    }
}
