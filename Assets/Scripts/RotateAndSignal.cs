using UnityEngine;

public class RotateAndSignal : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f; // ��ת�ٶȣ���/�룩

    private float totalRotation = 0f; // �ۼ���ת�Ƕ�

    void Update()
    {
        // ����ÿ֡Ӧ����ת�ĽǶ�
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // ��������ת����
        transform.Rotate(Vector3.left * rotationThisFrame);

        // �����ۼ���ת�Ƕ�
        totalRotation -= rotationThisFrame;

        // ÿ��ת180�ȣ������ۼƽǶ�
        if (Mathf.Abs(totalRotation) >= 180f)
        {
            totalRotation = 0f;
        }
    }
}
