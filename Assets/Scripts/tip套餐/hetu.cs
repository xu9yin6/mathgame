using UnityEngine;
using UnityEngine.UI;

public class hetu : MonoBehaviour
{
    public Button tip;
    public Image[] uiImages; // 用数组表示多个UI图像
    private int collisionCount = 0; // 碰撞计数器
    private bool isShowingImage = false; // 是否正在显示UI图像
    private int collisionThreshold = 8; // 触发显示UI图像的碰撞阈值

    void Start()
    {
        // 初始设置UI按钮不可交互
        tip.interactable = false;
        // 初始隐藏所有UI图像
        foreach (Image image in uiImages)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hetu")) 
        {
            // 每次碰撞计数器加1
            collisionCount++;
            tip.interactable = true;
            // 如果未显示UI图像并且碰撞次数达到阈值，则显示随机UI图像
            if (!isShowingImage && collisionCount >= collisionThreshold)
            {
                int randomIndex = Random.Range(0, uiImages.Length); // 随机选择一个UI图像索引
                uiImages[randomIndex].gameObject.SetActive(true); // 显示随机选择的UI图像
                Debug.Log("显示UI图像");
                isShowingImage = true; // 更新状态为正在显示UI图像
            }
        }
    }
}
