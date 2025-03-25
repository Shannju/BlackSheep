using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // 在Start方法中直接结束游戏
    void Start()
    {
        // 如果是在编辑模式下，可以退出播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 否则在构建后的版本中退出游戏
        Application.Quit();
#endif
    }
}
