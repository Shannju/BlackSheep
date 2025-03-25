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
                // ѭ�������ı�
                currentTextIndex = (currentTextIndex + 1) % customTexts.Count;

                // �����ı�
                modular3DText.UpdateText(customTexts[currentTextIndex]);

                // ����������һ���ı������� TriggerEvent1()
                if (currentTextIndex == customTexts.Count - 1)
                {
                    TriggerEvent1();
                }
            }
        }

        private void TriggerEvent1()
        {
            if (sceneEventManager != null)
            {
                sceneEventManager.OnEvent1Complete();
                Debug.Log("Event 1 completed!");
            }
            else
            {
                Debug.LogError("SceneEventManager reference is missing!");
            }
        }
    }
}
