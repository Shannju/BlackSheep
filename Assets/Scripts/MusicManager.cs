using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource mainMusicSource;     // ����������Դ
    public AudioSource secondaryMusicSource;  // �ڶ�������Դ

    private float nextPlayTime; // �´β��ŵڶ������ֵ�ʱ��

    void Start()
    {
        // ������Դѭ������
        mainMusicSource.loop = true;
        mainMusicSource.Play();

        // �ڶ�������Դ��ѭ��
        secondaryMusicSource.loop = false;

        // ��ʼ���´β���ʱ��
        nextPlayTime = Time.time + Random.Range(3f, 10f);
    }

    void Update()
    {
        // ������˲��ŵڶ������ֵ�ʱ��
        if (Time.time >= nextPlayTime && !secondaryMusicSource.isPlaying)
        {
            secondaryMusicSource.Play();
            // �������ֲ��ų���ʱ��
            StartCoroutine(StopSecondaryMusic(Random.Range(5f, 10f)));
            // ���������һ�β��ŵ�ʱ��
            nextPlayTime = Time.time + secondaryMusicSource.clip.length + Random.Range(5f, 10f);
        }
    }

    System.Collections.IEnumerator StopSecondaryMusic(float duration)
    {
        // �ȴ����ֲ���ָ����ʱ��
        yield return new WaitForSeconds(duration);

        // ��ͣ�ڶ�������
        secondaryMusicSource.Pause();
    }
}
