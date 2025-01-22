using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KnobControl : MonoBehaviour
{
    [SerializeField]
    private XRKnob knob;  // XRKnob 引用

    [SerializeField]
    private int maxTurns = 3;  // 最大旋转圈数，设置每 10 圈才旋转 360 度，降低速度

    private float currentValue = 0f;  // 当前旋钮的值

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
        // 更新当前旋钮的值
        currentValue = value;

        // 计算旋转角度：根据最大旋转圈数和旋钮值
        // value 范围通常是 0 到 1，我们将其映射到 (最大圈数 * 360) 范围内。
        float totalRotation = Mathf.Lerp(0f, 360f/ maxTurns, currentValue);

        // 将该角度应用到旋钮本身的y轴上（根据需要调整轴向）
        transform.localRotation = Quaternion.Euler(0, totalRotation, 0);
    }
}
