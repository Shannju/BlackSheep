using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KnobControl : MonoBehaviour
{
    [SerializeField]
    private XRKnob knob;  // XRKnob ����

    [SerializeField]
    private int maxTurns = 3;  // �����תȦ��������ÿ 10 Ȧ����ת 360 �ȣ������ٶ�

    private float currentValue = 0f;  // ��ǰ��ť��ֵ

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
        // ���µ�ǰ��ť��ֵ
        currentValue = value;

        // ������ת�Ƕȣ����������תȦ������ťֵ
        // value ��Χͨ���� 0 �� 1�����ǽ���ӳ�䵽 (���Ȧ�� * 360) ��Χ�ڡ�
        float totalRotation = Mathf.Lerp(0f, 360f/ maxTurns, currentValue);

        // ���ýǶ�Ӧ�õ���ť�����y���ϣ�������Ҫ��������
        transform.localRotation = Quaternion.Euler(0, totalRotation, 0);
    }
}
