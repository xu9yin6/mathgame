using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    public GameObject yaoGan;
    public GameObject tiaoYue;
    public GameObject suanPan;
    public 手机摇杆控制 phone;
    public 相机阻尼 cameraM;
    public Camera cma;
    public Transform suanPant;
    public List<float> timestamps = new List<float>();
    private void Awake()
    {
        // 确保只有一个实例存在
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 防止切换场景时销毁该对象
        }
        else
        {
            Destroy(gameObject); // 如果已经有实例存在，则销毁重复的对象
        }
    }

    public void PingChang()
    {
        yaoGan.SetActive(true);
        tiaoYue.SetActive(true);
        phone.enabled = true;
        cameraM.enabled = true;
        suanPan.SetActive(false);
    }

    public void ZhanDou()
    {
        suanPant.position = cma.ScreenToWorldPoint(new Vector3(Screen.width * 0.27f, Screen.height * 0.5f, 10f));
        yaoGan.SetActive(false);
        tiaoYue.SetActive(false);
        phone.enabled = false;
        cameraM.enabled = false;
        suanPan.SetActive(true);
    }
}
