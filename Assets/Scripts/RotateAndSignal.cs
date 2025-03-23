using UnityEngine;

public class RotateAndSignal : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f; // 旋转速度（度/秒）

    private float totalRotation = 0f; // 累计旋转角度

    void Update()
    {
        // 计算每帧应该旋转的角度
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // 反方向旋转对象
        transform.Rotate(Vector3.left * rotationThisFrame);

        // 更新累计旋转角度
        totalRotation -= rotationThisFrame;

        // 每旋转180度，重置累计角度
        if (Mathf.Abs(totalRotation) >= 180f)
        {
            totalRotation = 0f;
        }
    }
}
