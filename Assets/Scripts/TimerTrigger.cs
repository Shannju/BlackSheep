using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerTrigger : MonoBehaviour
{
    // 计时器
    private float timer = 0f;
    // 最大时间（100秒）
    public float maxTime = 100f;

    // 定义Unity事件列表
    public UnityEvent onTimerComplete;

    void Update()
    {
        // 计时器加速
        if (timer < maxTime)
        {
            timer += Time.deltaTime;
        }

        // 如果计时器达到最大时间，触发事件
        if (timer >= maxTime)
        {
            if (onTimerComplete != null)
            {
                onTimerComplete.Invoke();
            }
            // 重置计时器，或者您可以选择销毁脚本或其他操作
            timer = 0f;
        }
    }
}
