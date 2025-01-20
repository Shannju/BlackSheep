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
        // ʵ����Ϸ��ͣ�߼�
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        // ʵ����Ϸ�ָ��߼�
        Time.timeScale = 1;
    }
}
