using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 收取物件 : MonoBehaviour
{
    public GameObject 图像;
    public GameObject 背景;
    public Text 名称;
    public Button collectButton;
    public Button declineButton;
    public Text 已寻回;

    private bool isInteracting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isInteracting)
        {
            isInteracting = true;
            图像.SetActive(true);
            背景.SetActive(true);

            名称.gameObject.SetActive(true);
            collectButton.gameObject.SetActive(true);
            declineButton.gameObject.SetActive(true);
            已寻回.gameObject.SetActive(false);

            // 设置事件监听器
            collectButton.onClick.AddListener(OnCollectButtonClicked);
            declineButton.onClick.AddListener(OnDeclineButtonClicked);
        }
    }

    public void OnCollectButtonClicked()
    {
        Debug.Log("已点击");
        已寻回.gameObject.SetActive(true);
        图像.SetActive(false);
        背景.SetActive(false);

        名称.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(false);
        declineButton.gameObject.SetActive(false);

        // 移除事件监听器，避免重复调用
        collectButton.onClick.RemoveListener(OnCollectButtonClicked);
        declineButton.onClick.RemoveListener(OnDeclineButtonClicked);
    }


    public void OnDeclineButtonClicked()
    {
        Debug.Log("已点击");
        图像.SetActive(false);
        背景.SetActive(false);

        名称.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(false);
        declineButton.gameObject.SetActive(false);

        // 移除事件监听器，避免重复调用
        collectButton.onClick.RemoveListener(OnCollectButtonClicked);
        declineButton.onClick.RemoveListener(OnDeclineButtonClicked);
    }
}
