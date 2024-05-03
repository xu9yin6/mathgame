using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 触发剧情 : MonoBehaviour
{
    public Transform player; 
    public Transform npc;
    public float 触发距离 = 3f;
    public Button 消息; 
    public Transform 剧情;
    public Transform chatManager;

    public Transform 摇杆;
    public Transform 跳跃;

    private bool 触发器 = false;

    void Start()
    {
        消息.gameObject.SetActive(false);
        消息.onClick.AddListener(触发按钮);
    }
    void Update()
    {
        float distance = Vector3.Distance(player.position, npc.position);

        if (distance <= 触发距离 && !触发器)
        {
            消息.gameObject.SetActive(true);
            触发器 = true;
            //触发按钮();
            摇杆.gameObject.SetActive(false);
            跳跃.gameObject.SetActive(false);
        }
    }

    public void 触发按钮()
    {
        Debug.Log("button被点击");
        if (剧情 != null)
        {
            剧情.gameObject.SetActive(true);
            chatManager.gameObject.SetActive(true);
            消息.gameObject.SetActive(false);
        }
    }

}
