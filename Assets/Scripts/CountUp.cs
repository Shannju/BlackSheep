using System.Collections;
using UnityEngine;
using UnityEngine.Events; // 引入 UnityEvent

namespace TinyGiantStudio.Text.Example
{
    public class CountUp : MonoBehaviour
    {
        [SerializeField] bool startCountdownOnStart = true;
        [Space]
        [SerializeField] Modular3DText modular3DText = null;
        [Space]
        [SerializeField] string textAfterCountdownEnds = "";
        [SerializeField] int startCount = 60; // 从60开始计数
        [SerializeField] int endCount = 100; // 计数结束时的数值
        [SerializeField] float timeStep = 1f; // 每秒跳一次

        [Header("Events")]
        public UnityEvent count100; // 当计数到100时触发的事件

        void Start()
        {
            if (startCountdownOnStart && modular3DText)
                StartCoroutine(CountdownRoutine());
        }

        IEnumerator CountdownRoutine()
        {
            int currentCount = startCount;

            // 循环进行计数直到达到100
            while (currentCount <= endCount)
            {
                modular3DText.UpdateText(currentCount.ToString());
                yield return new WaitForSeconds(timeStep); // 每秒跳一次

                if (currentCount == 100)
                {
                    // 当计数到达100时，触发 count100 信号
                    Debug.LogWarning("110");
                    // 停顿 1 秒（你可以根据需要修改时间）
                    yield return new WaitForSeconds(3f);
                    count100.Invoke();
                }

                currentCount++;
            }

            yield return new WaitForSeconds(1);
            modular3DText.UpdateText(textAfterCountdownEnds);
        }
    }
}
