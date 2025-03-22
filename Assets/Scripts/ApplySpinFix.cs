using UnityEngine;

public class ApplySpinFix : MonoBehaviour
{
    // ����һ����ת��
    public Vector3 torqueDirection = new Vector3(0f, 1f, 0f); // Ĭ����Y����ת
    public float torqueStrength = 10f; // ��ת��ǿ��

    private Rigidbody rb;

    void Start()
    {
        // ��ȡ Rigidbody ���
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ͨ�� AddTorque ���һ����ת��
        rb.AddTorque(torqueDirection.normalized * torqueStrength);
    }
}
