using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    public GameObject yaoGan;
    public GameObject tiaoYue;
    public GameObject suanPan;
    public �ֻ�ҡ�˿��� phone;
    public ������� cameraM;
    public Camera cma;
    public Transform suanPant;
    public List<float> timestamps = new List<float>();
    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��ֹ�л�����ʱ���ٸö���
        }
        else
        {
            Destroy(gameObject); // ����Ѿ���ʵ�����ڣ��������ظ��Ķ���
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
