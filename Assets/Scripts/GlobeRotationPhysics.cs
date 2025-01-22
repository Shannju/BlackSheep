using UnityEngine;

public class GlobeRotationPhysics : MonoBehaviour
{
    public float rotationSpeed = 100f; // 旋转的初始速度（度/秒）
    public Vector3 rotationAxis = Vector3.up; // 旋转的轴，默认为绕 Y 轴旋转
    public float rotationDecay = 2f; // 旋转速度衰减时间（秒）

    private bool isRotating = false; // 标志是否正在旋转
    private float currentSpeed; // 当前旋转速度
    private float elapsedTime; // 已经过的时间

    void Start()
    {
        // 初始化速度和时间
        currentSpeed = 0f;
        elapsedTime = 0f;
    }

    // 碰撞检测，触发旋转
    void OnCollisionEnter(Collision collision)
    {
        // 当检测到碰撞时，设置旋转状态
        isRotating = true;
        currentSpeed = rotationSpeed; // 设置初始速度
        elapsedTime = 0f;

        // 可选：输出调试信息
        Debug.Log($"Collision detected with: {collision.gameObject.name}");
    }

    void Update()
    {
        if (isRotating)
        {
            // 逐渐减速
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDecay);
            currentSpeed = Mathf.Lerp(rotationSpeed, 0, t);

            // 执行旋转
            transform.Rotate(rotationAxis, currentSpeed * Time.deltaTime);

            // 当速度接近 0 时，停止旋转
            if (currentSpeed <= 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
