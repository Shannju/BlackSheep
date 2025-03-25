using UnityEngine;
using System.Collections.Generic;

namespace TinyGiantStudio.Text.Example
{
    public class TextSwitcher1 : MonoBehaviour
    {
        [SerializeField] Modular3DText modular3DText = null; // ������ʾ�ı������
        [Space]
        [SerializeField] List<string> customTexts = new List<string>();  // �Զ����ı��б�
        private int currentTextIndex = 0;  // ��ǰ��ʾ���ı�����

        public SceneEventManager0 sceneEventManager;
        public int eventNumber;  // ����ѡ�񴥷��ĸ��¼�

        // Start() �в������κγ�ʼ��
        void Start()
        {
            // ��ѡ����ʼ��ʱ��ʾ��һ���ı�
            if (customTexts.Count > 0 && modular3DText != null)
                modular3DText.UpdateText(customTexts[currentTextIndex]);
        }

        // �����л��ı��ĺ���
        public void SwitchText()
        {
            Debug.Log("change text");
            if (customTexts.Count > 0 && modular3DText != null)
            {
                // ����������һ���ı�������ָ�����¼�
                if (currentTextIndex == customTexts.Count - 1)
                {
                    modular3DText.UpdateText(customTexts[currentTextIndex]);
                    TriggerEventBasedOnNumber(eventNumber);
                    return;
                }
                // ѭ�������ı�
                currentTextIndex = (currentTextIndex + 1) % customTexts.Count;

                // �����ı�
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
