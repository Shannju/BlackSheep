using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInteractorColorChange : MonoBehaviour
{
    public Color highlightColor = Color.white;  // ������ɫ����ɫ���⣩
    private XRBaseInteractor interactor;

    private void Awake()
    {
        // ��ȡ interactor ���
        interactor = GetComponent<XRBaseInteractor>();
        if (interactor == null)
        {
            Debug.LogError("No XRBaseInteractor component found on this GameObject!");
        }
    }

    private void OnEnable()
    {
        // ���� Hover �¼�
        interactor.hoverEntered.AddListener(OnHoverEntered);
        interactor.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDisable()
    {
        // ȡ������ Hover �¼�
        interactor.hoverEntered.RemoveListener(OnHoverEntered);
        interactor.hoverExited.RemoveListener(OnHoverExited);
    }

    // ��������Ӵ�ʱ��Ϊ��ɫ����
    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // ��ȡ����� Renderer
        GameObject targetObject = args.interactableObject.transform.gameObject;
        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            // ���÷���
            renderer.material.EnableKeyword("_EMISSION");

            // ���÷�����ɫΪ��ɫ
            renderer.material.SetColor("_EmissionColor", highlightColor);

            // ȷ��������ɫ��ʾΪ�����ɫ
            renderer.material.color = Color.white;
        }
    }

    // ���������뿪ʱ�ָ���ɫ
    private void OnHoverExited(HoverExitEventArgs args)
    {
        // ��ȡ����� Renderer
        GameObject targetObject = args.interactableObject.transform.gameObject;
        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            // �رշ���Ч��
            renderer.material.DisableKeyword("_EMISSION");

            // �ָ�Ϊԭ���Ĳ�����ɫ
            renderer.material.color = Color.white;
        }
    }
}
