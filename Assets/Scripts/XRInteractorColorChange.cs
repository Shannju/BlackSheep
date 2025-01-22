using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInteractorColorChange : MonoBehaviour
{
    public Color highlightColor = Color.white;  // 高亮颜色（白色发光）
    private XRBaseInteractor interactor;

    private void Awake()
    {
        // 获取 interactor 组件
        interactor = GetComponent<XRBaseInteractor>();
        if (interactor == null)
        {
            Debug.LogError("No XRBaseInteractor component found on this GameObject!");
        }
    }

    private void OnEnable()
    {
        // 监听 Hover 事件
        interactor.hoverEntered.AddListener(OnHoverEntered);
        interactor.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDisable()
    {
        // 取消监听 Hover 事件
        interactor.hoverEntered.RemoveListener(OnHoverEntered);
        interactor.hoverExited.RemoveListener(OnHoverExited);
    }

    // 当与物体接触时变为白色发光
    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // 获取物体的 Renderer
        GameObject targetObject = args.interactableObject.transform.gameObject;
        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            // 启用发光
            renderer.material.EnableKeyword("_EMISSION");

            // 设置发光颜色为白色
            renderer.material.SetColor("_EmissionColor", highlightColor);

            // 确保物体颜色显示为发光白色
            renderer.material.color = Color.white;
        }
    }

    // 当与物体离开时恢复颜色
    private void OnHoverExited(HoverExitEventArgs args)
    {
        // 获取物体的 Renderer
        GameObject targetObject = args.interactableObject.transform.gameObject;
        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            // 关闭发光效果
            renderer.material.DisableKeyword("_EMISSION");

            // 恢复为原本的材质颜色
            renderer.material.color = Color.white;
        }
    }
}
