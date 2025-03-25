using UnityEngine;

public class SmoothTransform : MonoBehaviour
{
    public float targetZ = -7f;  // Ŀ��Z��λ��
    public float targetScale = 300f;  // Ŀ�����ű���
    public float moveSpeed = 2f;  // �ƶ��ٶ�
    public float scaleSpeed = 2f;  // �����ٶ�

    private Vector3 startScale;
    private Vector3 targetPosition;

    void Start()
    {
        // ��¼��ʼ����
        startScale = transform.localScale;

        // ����Ŀ��λ�õĳ�ʼֵ
        targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
    }

    void Update()
    {
        // ƽ���ƶ���Ŀ��Z��λ��
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // ƽ�����ŵ�Ŀ��ֵ
        float targetScaleValue = targetScale;
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScaleValue, targetScaleValue, targetScaleValue), scaleSpeed * Time.deltaTime);
    }
}
