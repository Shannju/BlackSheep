using UnityEngine;
using UnityEditor;

public class PivotToCenterEditor : EditorWindow
{
    // 创建编辑器窗口
    [MenuItem("Tools/Move Pivot to Center")]
    public static void ShowWindow()
    {
        // 显示工具窗口
        GetWindow<PivotToCenterEditor>("Pivot to Center");
    }

    // 编辑器工具窗口 GUI
    void OnGUI()
    {
        GUILayout.Label("Move Pivot to Center for Selected Objects", EditorStyles.boldLabel);

        if (GUILayout.Button("Move Pivot to Center"))
        {
            MovePivotToCenter();
        }
    }

    // 运行时执行的工具方法
    private void MovePivotToCenter()
    {
        // 获取当前选中的所有物体
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (var obj in selectedObjects)
        {
            // 获取物体的 Renderer
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // 获取包围盒的中心点
                Vector3 center = renderer.bounds.center;

                // 计算物体当前的位置偏移
                Vector3 offset = obj.transform.position - center;

                // 将物体的位置移到包围盒的中心
                obj.transform.position = center;

                // 通过偏移保持物体的相对位置
                obj.transform.Translate(offset, Space.World);
            }
            else
            {
                Debug.LogWarning($"No Renderer found on {obj.name}. Skipping.");
            }
        }

        // 刷新编辑器窗口，以便查看结果
        SceneView.RepaintAll();
    }
}
