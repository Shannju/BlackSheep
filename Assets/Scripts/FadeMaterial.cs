using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public bool fadeIn = true; // ���Ƶ���򵭳��ķ���
    public float duration = 2f; // ���ɵĳ���ʱ��
    private Material material;
    private Color targetColor;
    private Color initialColor;
    private float timeElapsed = 0f;

    void Start()
    {
        // ��ȡ����Ĳ���
        material = GetComponent<Renderer>().material;

        // ��ȡ��ǰ���ʵ���ɫ
        initialColor = material.color;

        // ���� fadeIn ����Ŀ����ɫ
        if (fadeIn)
        {
            targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f); // ���룬Ŀ��͸����Ϊ 1
        }
        else
        {
            targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // ������Ŀ��͸����Ϊ 0
        }
    }

    void Update()
    {
        // ���㵱ǰ���ɵı���
        timeElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(timeElapsed / duration);

        // ���� t ֵ������ɫ�� alpha ͨ��
        material.color = Color.Lerp(initialColor, targetColor, t);

        // ���ʱ���ѹ���ֹͣ����
        if (t >= 1f)
        {
            enabled = false; // ���ýű���ֹͣ����
        }
    }
}
