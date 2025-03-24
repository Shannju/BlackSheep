using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public bool fadeIn = true; // 控制淡入或淡出的方向
    public float duration = 2f; // 过渡的持续时间
    private Material material;
    private Color targetColor;
    private Color initialColor;
    private float timeElapsed = 0f;

    void Start()
    {
        // 获取物体的材质
        material = GetComponent<Renderer>().material;

        // 获取当前材质的颜色
        initialColor = material.color;

        // 根据 fadeIn 设置目标颜色
        if (fadeIn)
        {
            targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f); // 淡入，目标透明度为 1
        }
        else
        {
            targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // 淡出，目标透明度为 0
        }
    }

    void Update()
    {
        // 计算当前过渡的比例
        timeElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(timeElapsed / duration);

        // 根据 t 值调整颜色的 alpha 通道
        material.color = Color.Lerp(initialColor, targetColor, t);

        // 如果时间已过，停止过渡
        if (t >= 1f)
        {
            enabled = false; // 禁用脚本，停止更新
        }
    }
}
