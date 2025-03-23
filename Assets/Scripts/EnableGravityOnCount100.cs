using UnityEngine;
using UnityEngine.Events;

public class EnableGravityOnCount100 : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent count100; // 用于监听 count100 信号

    private Rigidbody rb;

    void Start()
    {
        // 获取物体上的 Rigidbody 组件
        rb = GetComponent<Rigidbody>();

        // 如果没有 Rigidbody 组件，打印警告信息
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody component found on this GameObject.");
        }

        // 订阅 count100 信号
        if (count100 != null)
        {
            count100.AddListener(EnableGravity);
        }
    }

    // 启用刚体的重力
    void EnableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = true; // 启用重力
        }
    }

    void OnDisable()
    {
        // 取消订阅 count100 信号，防止内存泄漏
        if (count100 != null)
        {
            count100.RemoveListener(EnableGravity);
        }
    }
}
