using UnityEngine;

public class UIEventTrigger : MonoBehaviour
{
    public void LoadGame()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.RequestSceneLoad("DemoSceneMy");
            Debug.Log("loading game!!!");
        }
        else
        {
            Debug.LogError("EventManager instance not found!");
        }
    }
}
