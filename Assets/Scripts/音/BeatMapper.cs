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
        filePath ="D:\\文档\\GitHub\\mathgame\\Assets\\Models\\时间戳.txt";
        // 获取场景中的 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Play();
        }
        // 监听玩家点击屏幕的事件
        if (audioSource.isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RecordTimestamp(); // 点击时记录时间戳
                SaveTimestamps(); // 保存时间戳数据
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
        // 将时间戳列表保存到文件
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float ts in timestamps)
            {
                writer.WriteLine(ts.ToString());
            }
        }
    }
}
