using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class 音量控制 : MonoBehaviour
{
    public static float volume; // 用于存储音频的音量信息
    private List<float> volumeHistory = new List<float>(); // 用于记录音频数值的列表
    private AudioClip 声音音频; // 用于存储从麦克风录制的音频
    string device; // 用于存储麦克风设备的名称

    public int speed; // 拖尾的移动速度
    private float x;

    private bool scriptEnabled = false; // 是否启用脚本的标志
    private GameObject shiban;
    public Text 提示;

    public int 方向;

    void Start()
    {
        提示.gameObject.SetActive(false);
        // 初始化速度的值
        speed = 5;
        device = Microphone.devices[0]; // 获取设备麦克风
        声音音频 = Microphone.Start(device, true, 999, 44100); // 44100音频采样率

        shiban = GameObject.FindWithTag("shiban");

    }

    void Update()
    {
        // 检查是否启用脚本
        if (!scriptEnabled)
            return;

        // 获取当前音频的最大音量，并将其存储在 volume 变量中
        volume = GetMaxVolume();

        // 将当前音量值添加到记录音量的列表中
        volumeHistory.Add(volume);

        Debug.Log("当前音量值：" + volume);
        Debug.Log("准备好了吗，海绵宝宝");


        // 处理音频大小控制shiban移动
        if (volume > 0.15f) // 根据需要调整阈值
        {
            Debug.Log("我准备好了");
            // 控制shiban移动
            if(方向 == 0)//右
            {
                shiban.transform.position -= Vector3.left * speed * Time.deltaTime; // 将对象移动，根据音量值
            }
            if(方向 == 1)//左
            {
                shiban.transform.position -= Vector3.right * speed * Time.deltaTime; // 将对象移动，根据音量值
            }
            if(方向 == 2)//上
            {
                shiban.transform.position -= Vector3.down * speed * Time.deltaTime; // 将对象移动，根据音量值
            }if(方向 == 3)//下
            {
                shiban.transform.position -= Vector3.up * speed * Time.deltaTime; // 将对象移动，根据音量值
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("发生碰撞");
            scriptEnabled = true;

            提示.gameObject.SetActive(true);
            
            // 启动协程来隐藏文本
            StartCoroutine(HideTextAfterDelay(5f));
        }
    }

    // 协程以延迟隐藏文本
    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // 隐藏文本
        提示.gameObject.SetActive(false);
    }


    // 每一帧处理那一帧接收的音频文件
    float GetMaxVolume()
    {
        Debug.Log("获取音频");

        float maxVolume = 0f;
        // 剪切音频
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(device) - 128 + 1;
        if (offset < 0)
        {
            return 0;
        }
        声音音频.GetData(volumeData, offset);

        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i]; // 修改音量的敏感值
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;
    }

}
