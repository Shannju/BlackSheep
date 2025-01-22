using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KnobControl : MonoBehaviour
{
    [SerializeField]
    private XRKnob knob;  // XRKnob 引用

    [SerializeField]
    private int maxTurns = 10;  // 每 10 圈方向盘，物体旋转 1 圈

    private float lastKnobValue = 0f;  // 上次旋钮的值
    private float currentRotation = 0f;  // 当前物体的旋转角度

    void Start()
    {
        // 监听旋钮的值变化
        if (knob != null)
        {
            knob.onValueChange.AddListener(OnKnobValueChanged);
        }
    }

    void OnDestroy()
    {
        // 移除监听
        if (knob != null)
        {
            knob.onValueChange.RemoveListener(OnKnobValueChanged);
        }
    }

    // 旋钮值变化时的回调
    void OnKnobValueChanged(float value)
    {
        // 计算旋钮的变化量
        float deltaValue = value - lastKnobValue;  // 旋钮的增量

        // 计算旋转增量：每转 maxTurns 圈，物体才转 1 圈
        float rotationIncrement = deltaValue * 360f / maxTurns;

        // 更新物体的旋转角度
        currentRotation += rotationIncrement;

        // 将旋转角度应用到物体
        transform.localRotation = Quaternion.Euler(0, currentRotation, 0);

        // 更新上次旋钮的值
        lastKnobValue = value;
    }
}
