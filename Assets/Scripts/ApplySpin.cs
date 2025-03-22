using UnityEngine;

public class ApplyRandomSpin : MonoBehaviour
{
    // 旋转的强度
    public float torqueStrength = 1f;

    private Rigidbody rb;

    void Start()
    {
        // 获取 Rigidbody 组件
        rb = GetComponent<Rigidbody>();

        // 随机生成旋转方向
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // 正规化旋转方向，确保旋转力均匀
        randomDirection.Normalize();

        // 通过 AddTorque 添加一个旋转力
        rb.AddTorque(randomDirection * torqueStrength);
    }
}
