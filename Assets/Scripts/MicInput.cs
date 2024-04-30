using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    //存储音量值
    public static float volume;

    //用于麦克风录音的AudioClip对象
    AudioClip micRecord;
    
    //设备
    string device;

    void Start()
    {
        //获取第一个设备名称
        device = Microphone.devices[0];
        //录音
        micRecord = Microphone.Start(device, true, 999, 44100);

    }

    void Update()
    {
        //更新音量值
        volume = GetMaxVolume();
    }

    float GetMaxVolume()
    {
        //初始化
        float maxVolume = 0f;
        //存储音频数据
        float[] volumeData =new float[128];
        //计算当前录音位置的偏移量
        int offset = Microphone.GetPosition(device) -128 +1;
        if(offset < 0)//过小
        {
            return 0;
        }
        
        //存入音频数据于volumeData数组
        micRecord.GetData(volumeData, offset);

        //获取峰值
        for(int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];
            if(maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;
    }
}
