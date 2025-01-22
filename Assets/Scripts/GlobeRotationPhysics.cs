using UnityEngine;

public class GlobeRotationPhysics : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��ת�ĳ�ʼ�ٶȣ���/�룩
    public Vector3 rotationAxis = Vector3.up; // ��ת���ᣬĬ��Ϊ�� Y ����ת
    public float rotationDecay = 2f; // ��ת�ٶ�˥��ʱ�䣨�룩

    private bool isRotating = false; // ��־�Ƿ�������ת
    private float currentSpeed; // ��ǰ��ת�ٶ�
    private float elapsedTime; // �Ѿ�����ʱ��

    void Start()
    {
        // ��ʼ���ٶȺ�ʱ��
        currentSpeed = 0f;
        elapsedTime = 0f;
    }

    // ��ײ��⣬������ת
    void OnCollisionEnter(Collision collision)
    {
        // ����⵽��ײʱ��������ת״̬
        isRotating = true;
        currentSpeed = rotationSpeed; // ���ó�ʼ�ٶ�
        elapsedTime = 0f;

        // ��ѡ�����������Ϣ
        Debug.Log($"Collision detected with: {collision.gameObject.name}");
    }

    void Update()
    {
        if (isRotating)
        {
            // �𽥼���
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDecay);
            currentSpeed = Mathf.Lerp(rotationSpeed, 0, t);

            // ִ����ת
            transform.Rotate(rotationAxis, currentSpeed * Time.deltaTime);

            // ���ٶȽӽ� 0 ʱ��ֹͣ��ת
            if (currentSpeed <= 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
