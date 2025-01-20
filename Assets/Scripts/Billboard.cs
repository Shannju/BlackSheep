using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTransform;

    private void Start()
    {
        // 获取主相机的Transform
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        // 使Canvas的正面始终面对相机
        Vector3 direction = camTransform.position - transform.position;
        direction.y = 0; // 仅调整Y轴旋转

        // 计算旋转
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(0, 180, 0); // 在Y轴上加上180度的旋转

        // 应用旋转
        transform.rotation = rotation;
    }
}
