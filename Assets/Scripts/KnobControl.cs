using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KnobControl : MonoBehaviour
{
    [SerializeField]
    private XRKnob knob;  // XRKnob ����

    [SerializeField]
    private int maxTurns = 10;  // ÿ 10 Ȧ�����̣�������ת 1 Ȧ

    private float lastKnobValue = 0f;  // �ϴ���ť��ֵ
    private float currentRotation = 0f;  // ��ǰ�������ת�Ƕ�

    void Start()
    {
        // ������ť��ֵ�仯
        if (knob != null)
        {
            knob.onValueChange.AddListener(OnKnobValueChanged);
        }
    }

    void OnDestroy()
    {
        // �Ƴ�����
        if (knob != null)
        {
            knob.onValueChange.RemoveListener(OnKnobValueChanged);
        }
    }

    // ��ťֵ�仯ʱ�Ļص�
    void OnKnobValueChanged(float value)
    {
        // ������ť�ı仯��
        float deltaValue = value - lastKnobValue;  // ��ť������

        // ������ת������ÿת maxTurns Ȧ�������ת 1 Ȧ
        float rotationIncrement = deltaValue * 360f / maxTurns;

        // �����������ת�Ƕ�
        currentRotation += rotationIncrement;

        // ����ת�Ƕ�Ӧ�õ�����
        transform.localRotation = Quaternion.Euler(0, currentRotation, 0);

        // �����ϴ���ť��ֵ
        lastKnobValue = value;
    }
}
