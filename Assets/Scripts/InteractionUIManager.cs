using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUIManager : MonoBehaviour
{
    private GameObject interactionUI;  // UI Container �µ� Interaction UI ����
    private TextMeshProUGUI headerText;  // Header Text �� TextMeshProUGUI ���
    private TextMeshProUGUI contentText;  // Content Text �� TextMeshProUGUI ���

    // �������б������ⲿ���ʺ��޸�
    public List<string> headerTextList = new List<string>();
    public List<string> contentTextList = new List<string>();

    private int headerIndex = 0;  // ��ǰ Header Text ��ʾ��λ��
    private int contentIndex = 0;  // ��ǰ Content Text ��ʾ��λ��

    // �趨 UI �ؼ��ĳ�ʼ״̬
    void Start()
    {
        interactionUI = gameObject;  // Ĭ�� UI Container �ǹ��ش˽ű�������

        // ���������岢��ȡ TextMeshProUGUI ���
        headerText = interactionUI.transform.Find("Header Text")?.GetComponent<TextMeshProUGUI>();
        contentText = interactionUI.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();

        if (headerText == null || contentText == null)
        {
            Debug.LogError("Header Text or Content Text is missing!");
        }

        // ��ʼ��ʱ��ʾ�б��еĵ�һ��
        UpdateHeaderText();
        UpdateContentText();
    }

    // ���� Header Text �� Content Text ���
    public void EnableTextComponents(bool enable)
    {
        if (headerText != null)
            headerText.enabled = enable;
        if (contentText != null)
            contentText.enabled = enable;
    }

    // ��������ı����������
    public void ClearTextComponents()
    {
        if (headerText != null)
            headerText.text = string.Empty;
        if (contentText != null)
            contentText.text = string.Empty;
    }

    // �� Header Text ���б�������µ����
    public void AddHeaderText(string newText)
    {
        if (!string.IsNullOrEmpty(newText))
        {
            headerTextList.Add(newText);
            UpdateHeaderText();
        }
    }

    // �� Content Text ���б�������µ����
    public void AddContentText(string newText)
    {
        if (!string.IsNullOrEmpty(newText))
        {
            contentTextList.Add(newText);
            UpdateContentText();
        }
    }

    // ���� Header Text ����ʾ����
    private void UpdateHeaderText()
    {
        if (headerText != null && headerTextList.Count > 0 && headerIndex < headerTextList.Count)
        {
            headerText.text = headerTextList[headerIndex];  // ֻ��ʾ��ǰ����������
        }
    }

    // ���� Content Text ����ʾ����
    private void UpdateContentText()
    {
        if (contentText != null && contentTextList.Count > 0 && contentIndex < contentTextList.Count)
        {
            contentText.text = contentTextList[contentIndex];  // ֻ��ʾ��ǰ����������
        }
    }

    // �л��� Header Text �б��е���һ��
    public void SwitchToNextHeaderText()
    {
        if (headerIndex < headerTextList.Count - 1)
        {
            headerIndex++;
            UpdateHeaderText();
        }
        else
        {
            Debug.Log("No more items in the header text list.");
        }
    }

    // �л��� Content Text �б��е���һ��
    public void SwitchToNextContentText()
    {
        if (contentIndex < contentTextList.Count - 1)
        {
            contentIndex++;
            UpdateContentText();
        }
        else
        {
            Debug.Log("No more items in the content text list.");
        }
    }

    // ��� Header Text �� Content Text ���ı��б�
    public void ClearTextLists()
    {
        headerTextList.Clear();
        contentTextList.Clear();
        headerIndex = 0;  // ���ʱ��������
        contentIndex = 0;
        UpdateHeaderText();
        UpdateContentText();
    }

    // �����ӿڹ��ⲿ����ı�
    public void AddTextToHeaderList(string newText)
    {
        AddHeaderText(newText);
    }

    public void AddTextToContentList(string newText)
    {
        AddContentText(newText);
    }

    // �����ڵ��ԣ���ӡ Header �� Content �б������
    public void PrintTextLists()
    {
        Debug.Log("Header Text List:");
        foreach (string header in headerTextList)
        {
            Debug.Log(header);
        }

        Debug.Log("Content Text List:");
        foreach (string content in contentTextList)
        {
            Debug.Log(content);
        }
    }
}
