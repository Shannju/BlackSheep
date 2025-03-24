using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUIManager : MonoBehaviour
{
    private GameObject interactionUI;  // UI Container 下的 Interaction UI 物体
    private TextMeshProUGUI headerText;  // Header Text 的 TextMeshProUGUI 组件
    private TextMeshProUGUI contentText;  // Content Text 的 TextMeshProUGUI 组件

    // 公开的列表，允许外部访问和修改
    public List<string> headerTextList = new List<string>();
    public List<string> contentTextList = new List<string>();

    private int headerIndex = 0;  // 当前 Header Text 显示的位置
    private int contentIndex = 0;  // 当前 Content Text 显示的位置

    // 设定 UI 控件的初始状态
    void Start()
    {
        interactionUI = gameObject;  // 默认 UI Container 是挂载此脚本的物体

        // 查找子物体并获取 TextMeshProUGUI 组件
        headerText = interactionUI.transform.Find("Header Text")?.GetComponent<TextMeshProUGUI>();
        contentText = interactionUI.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();

        if (headerText == null || contentText == null)
        {
            Debug.LogError("Header Text or Content Text is missing!");
        }

        // 初始化时显示列表中的第一句
        UpdateHeaderText();
        UpdateContentText();
    }

    // 开启 Header Text 和 Content Text 组件
    public void EnableTextComponents(bool enable)
    {
        if (headerText != null)
            headerText.enabled = enable;
        if (contentText != null)
            contentText.enabled = enable;
    }

    // 清空两个文本组件的内容
    public void ClearTextComponents()
    {
        if (headerText != null)
            headerText.text = string.Empty;
        if (contentText != null)
            contentText.text = string.Empty;
    }

    // 向 Header Text 的列表中添加新的语句
    public void AddHeaderText(string newText)
    {
        if (!string.IsNullOrEmpty(newText))
        {
            headerTextList.Add(newText);
            UpdateHeaderText();
        }
    }

    // 向 Content Text 的列表中添加新的语句
    public void AddContentText(string newText)
    {
        if (!string.IsNullOrEmpty(newText))
        {
            contentTextList.Add(newText);
            UpdateContentText();
        }
    }

    // 更新 Header Text 的显示内容
    private void UpdateHeaderText()
    {
        if (headerText != null && headerTextList.Count > 0 && headerIndex < headerTextList.Count)
        {
            headerText.text = headerTextList[headerIndex];  // 只显示当前索引的内容
        }
    }

    // 更新 Content Text 的显示内容
    private void UpdateContentText()
    {
        if (contentText != null && contentTextList.Count > 0 && contentIndex < contentTextList.Count)
        {
            contentText.text = contentTextList[contentIndex];  // 只显示当前索引的内容
        }
    }

    // 切换到 Header Text 列表中的下一句
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

    // 切换到 Content Text 列表中的下一句
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

    // 清空 Header Text 和 Content Text 的文本列表
    public void ClearTextLists()
    {
        headerTextList.Clear();
        contentTextList.Clear();
        headerIndex = 0;  // 清空时重置索引
        contentIndex = 0;
        UpdateHeaderText();
        UpdateContentText();
    }

    // 公共接口供外部添加文本
    public void AddTextToHeaderList(string newText)
    {
        AddHeaderText(newText);
    }

    public void AddTextToContentList(string newText)
    {
        AddContentText(newText);
    }

    // 可用于调试，打印 Header 和 Content 列表的内容
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
