using UnityEngine;
using System.Collections.Generic;

namespace TinyGiantStudio.Text.Example
{
    public class TextSwitcher : MonoBehaviour
    {
        [SerializeField] Modular3DText modular3DText = null; // 用来显示文本的组件
        [Space]
        [SerializeField] List<string> customTexts = new List<string>();  // 自定义文本列表
        private int currentTextIndex = 0;  // 当前显示的文本索引

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
                // 循环更换文本
                currentTextIndex = (currentTextIndex + 1) % customTexts.Count;
                modular3DText.UpdateText(customTexts[currentTextIndex]);
            }
        }
    }
}
