using UnityEngine;

public class ApplySpinFix : MonoBehaviour
{
    // 定义一个旋转力
    public Vector3 torqueDirection = new Vector3(0f, 1f, 0f); // 默认绕Y轴旋转
    public float torqueStrength = 10f; // 旋转的强度

    private Rigidbody rb;

    void Start()
    {
        // 获取 Rigidbody 组件
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 通过 AddTorque 添加一个旋转力
        rb.AddTorque(torqueDirection.normalized * torqueStrength);
    }
}
