using UnityEngine;

public class GamePauseHandler : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Instance.OnGamePause += PauseGame;
        EventManager.Instance.OnGameResume += ResumeGame;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGamePause -= PauseGame;
        EventManager.Instance.OnGameResume -= ResumeGame;
    }

    private void PauseGame()
    {
        // 实现游戏暂停逻辑
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        // 实现游戏恢复逻辑
        Time.timeScale = 1;
    }
}
