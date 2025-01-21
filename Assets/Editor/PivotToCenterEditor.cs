using UnityEngine;
using UnityEditor;

public class PivotToCenterEditor : EditorWindow
{
    // �����༭������
    [MenuItem("Tools/Move Pivot to Center")]
    public static void ShowWindow()
    {
        // ��ʾ���ߴ���
        GetWindow<PivotToCenterEditor>("Pivot to Center");
    }

    // �༭�����ߴ��� GUI
    void OnGUI()
    {
        GUILayout.Label("Move Pivot to Center for Selected Objects", EditorStyles.boldLabel);

        if (GUILayout.Button("Move Pivot to Center"))
        {
            MovePivotToCenter();
        }
    }

    // ����ʱִ�еĹ��߷���
    private void MovePivotToCenter()
    {
        // ��ȡ��ǰѡ�е���������
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (var obj in selectedObjects)
        {
            // ��ȡ����� Renderer
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // ��ȡ��Χ�е����ĵ�
                Vector3 center = renderer.bounds.center;

                // �������嵱ǰ��λ��ƫ��
                Vector3 offset = obj.transform.position - center;

                // �������λ���Ƶ���Χ�е�����
                obj.transform.position = center;

                // ͨ��ƫ�Ʊ�����������λ��
                obj.transform.Translate(offset, Space.World);
            }
            else
            {
                Debug.LogWarning($"No Renderer found on {obj.name}. Skipping.");
            }
        }

        // ˢ�±༭�����ڣ��Ա�鿴���
        SceneView.RepaintAll();
    }
}
