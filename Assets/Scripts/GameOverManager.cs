using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // ��Start������ֱ�ӽ�����Ϸ
    void Start()
    {
        // ������ڱ༭ģʽ�£������˳�����ģʽ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �����ڹ�����İ汾���˳���Ϸ
        Application.Quit();
#endif
    }
}
