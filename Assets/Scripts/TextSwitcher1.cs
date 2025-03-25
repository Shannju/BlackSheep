using UnityEngine;
using System.Collections.Generic;

namespace TinyGiantStudio.Text.Example
{
    public class TextSwitcher1 : MonoBehaviour
    {
        [SerializeField] Modular3DText modular3DText = null; // 用来显示文本的组件
        [Space]
        [SerializeField] List<string> customTexts = new List<string>();  // 自定义文本列表
        private int currentTextIndex = 0;  // 当前显示的文本索引

        public SceneEventManager0 sceneEventManager;
        public int eventNumber;  // 用来选择触发哪个事件

        // Start() 中不再做任何初始化
        void Start()
        {
            // 可选：初始化时显示第一个文本
            if (customTexts.Count > 0 && modular3DText != null)
                modular3DText.UpdateText(customTexts[currentTextIndex]);
        }

        // 用来切换文本的函数
        public void SwitchText()
        {
            Debug.Log("change text");
            if (customTexts.Count > 0 && modular3DText != null)
            {
                // 如果到了最后一个文本，调用指定的事件
                if (currentTextIndex == customTexts.Count - 1)
                {
                    modular3DText.UpdateText(customTexts[currentTextIndex]);
                    TriggerEventBasedOnNumber(eventNumber);
                    return;
                }
                // 循环更换文本
                currentTextIndex = (currentTextIndex + 1) % customTexts.Count;

                // 更新文本
                modular3DText.UpdateText(customTexts[currentTextIndex]);
            }
        }

        private void TriggerEventBasedOnNumber(int eventNum)
        {
            if (sceneEventManager != null)
            {
                switch (eventNum)
                {
                    case 1:
                        sceneEventManager.OnEvent1Complete();
                        Debug.Log("Event 1 completed!");
                        break;
                    case 2:
                        sceneEventManager.OnEvent2Complete();
                        Debug.Log("Event 2 completed!");
                        break;
                    case 3:
                        sceneEventManager.OnEvent3Complete();
                        Debug.Log("Event 3 completed!");
                        break;
                    // Add more cases as needed for other events
                    default:
                        Debug.LogWarning("No event associated with the given number.");
                        break;
                }
            }
            else
            {
                Debug.LogError("SceneEventManager reference is missing!");
            }
        }
    }
}
