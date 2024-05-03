using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BeatMapper : MonoBehaviour
{
    private AudioSource audioSource;
    private List<float> timestamps = new List<float>();
    private string filePath;

    void Start()
    {
        filePath ="D:\\�ĵ�\\GitHub\\mathgame\\Assets\\Models\\ʱ���.txt";
        // ��ȡ�����е� AudioSource ���
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Play();
        }
        // ������ҵ����Ļ���¼�
        if (audioSource.isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RecordTimestamp(); // ���ʱ��¼ʱ���
                SaveTimestamps(); // ����ʱ�������
            }
        }

    }

    void RecordTimestamp()
    {
        float timestamp = audioSource.time;
        timestamps.Add(timestamp);
    }

    void SaveTimestamps()
    {
        // ��ʱ����б��浽�ļ�
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float ts in timestamps)
            {
                writer.WriteLine(ts.ToString());
            }
        }
    }
}
