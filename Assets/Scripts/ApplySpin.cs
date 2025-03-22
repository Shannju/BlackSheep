using UnityEngine;

public class ApplyRandomSpin : MonoBehaviour
{
    // ��ת��ǿ��
    public float torqueStrength = 1f;

    private Rigidbody rb;

    void Start()
    {
        // ��ȡ Rigidbody ���
        rb = GetComponent<Rigidbody>();

        // ���������ת����
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // ���滯��ת����ȷ����ת������
        randomDirection.Normalize();

        // ͨ�� AddTorque ���һ����ת��
        rb.AddTorque(randomDirection * torqueStrength);
    }
}
