using UnityEngine;
using UnityEngine.Events;

public class EnableGravityOnCount100 : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent count100; // ���ڼ��� count100 �ź�

    private Rigidbody rb;

    void Start()
    {
        // ��ȡ�����ϵ� Rigidbody ���
        rb = GetComponent<Rigidbody>();

        // ���û�� Rigidbody �������ӡ������Ϣ
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody component found on this GameObject.");
        }

        // ���� count100 �ź�
        if (count100 != null)
        {
            count100.AddListener(EnableGravity);
        }
    }

    // ���ø��������
    void EnableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = true; // ��������
        }
    }

    void OnDisable()
    {
        // ȡ������ count100 �źţ���ֹ�ڴ�й©
        if (count100 != null)
        {
            count100.RemoveListener(EnableGravity);
        }
    }
}
