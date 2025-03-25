using UnityEngine;

public class SmoothTransform : MonoBehaviour
{
    public float targetZ = -7f;  // 目标Z轴位置
    public float targetScale = 300f;  // 目标缩放比例
    public float moveSpeed = 2f;  // 移动速度
    public float scaleSpeed = 2f;  // 缩放速度

    private Vector3 startScale;
    private Vector3 targetPosition;

    void Start()
    {
        // 记录初始缩放
        startScale = transform.localScale;

        // 设置目标位置的初始值
        targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
    }

    void Update()
    {
        // 平滑移动到目标Z轴位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 平滑缩放到目标值
        float targetScaleValue = targetScale;
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScaleValue, targetScaleValue, targetScaleValue), scaleSpeed * Time.deltaTime);
    }
}
