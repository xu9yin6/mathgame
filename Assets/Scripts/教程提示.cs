using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 教程提示 : MonoBehaviour
{
    public float 摇杆教程 = 2f; 
    public float 跳跃教程 = 15f; 
    public Text text1;
    public Text text2;

    private bool text1Visible = false;
    private bool text2Visible = false;

    private bool text1Shown = false;
    private bool text2Shown = false;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Vector3.zero);

        if (distance >= 摇杆教程 && !text1Shown)
        {
            text1Shown = true;
            text1Visible = true;
            text1.gameObject.SetActive(true);
            Invoke("HideText1", 5f);
        }

        if (distance >= 跳跃教程 && !text2Shown)
        {
            text2Shown = true;
            text2Visible = true;
            text2.gameObject.SetActive(true);
            Invoke("HideText2", 5f);
        }
    }

    private void HideText1()
    {
        text1Visible = false;
        text1.gameObject.SetActive(false);
    }

    private void HideText2()
    {
        text2Visible = false;
        text2.gameObject.SetActive(false);
    }
}
