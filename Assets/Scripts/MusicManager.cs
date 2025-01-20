using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource mainMusicSource;     // 主背景音乐源
    public AudioSource secondaryMusicSource;  // 第二首音乐源

    private float nextPlayTime; // 下次播放第二首音乐的时间

    void Start()
    {
        // 主音乐源循环播放
        mainMusicSource.loop = true;
        mainMusicSource.Play();

        // 第二首音乐源不循环
        secondaryMusicSource.loop = false;

        // 初始化下次播放时间
        nextPlayTime = Time.time + Random.Range(3f, 10f);
    }

    void Update()
    {
        // 如果到了播放第二首音乐的时间
        if (Time.time >= nextPlayTime && !secondaryMusicSource.isPlaying)
        {
            secondaryMusicSource.Play();
            // 设置音乐播放持续时间
            StartCoroutine(StopSecondaryMusic(Random.Range(5f, 10f)));
            // 随机设置下一次播放的时间
            nextPlayTime = Time.time + secondaryMusicSource.clip.length + Random.Range(5f, 10f);
        }
    }

    System.Collections.IEnumerator StopSecondaryMusic(float duration)
    {
        // 等待音乐播放指定的时间
        yield return new WaitForSeconds(duration);

        // 暂停第二首音乐
        secondaryMusicSource.Pause();
    }
}
