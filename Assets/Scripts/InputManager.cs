using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject comBo;
    public Transform playerP;
    public Transform enemyP;
    public GameObject jiaoCheng;
    public GameObject jiFen;
    public Text comBoJ;
    public GameObject zhiShi;
    public Slider silder;
    public GameObject hp;
    public GameObject playerHP;
    public List<float> timestamps = new List<float>();
    public List<float> enemyTimestamps = new List<float>();
    public List<float> enemyjianHP = new List<float>();

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
        if (jiaoCheng != null)
        {
            jiaoCheng.SetActive(true);
            jiFen.SetActive(true);
        }

        suanPan.SetActive(false);
        comBo.SetActive(false);
        zhiShi.SetActive(false);
        hp.SetActive(false);
        playerHP.SetActive(false);
}

public void ZhanDou()
    {
        suanPant.position = cma.ScreenToWorldPoint(new Vector3(Screen.width * 0.27f, Screen.height * 0.5f, 10f));
        yaoGan.SetActive(false);
        tiaoYue.SetActive(false);
        phone.enabled = false;
        cameraM.enabled = false;
        if (jiaoCheng != null)
        {
            jiaoCheng.SetActive(false);
            jiFen.SetActive(false);
        }

        suanPan.SetActive(true);
        comBo.SetActive(true);
        zhiShi.SetActive(true);
        hp.SetActive(true);
        playerHP.SetActive(true);
    }
}
