using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class 错误答案 : MonoBehaviour
{
    public Image uiImage;  // 引用要激活和关闭的UI图像

    void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();
        
        // 添加按钮点击事件监听器
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogWarning("未找到按钮组件");
        }
    }

    // 按钮点击事件处理方法
    void OnButtonClicked()
    {
        // 检查UI图像是否存在
        if (uiImage != null)
        {
            // 激活UI图像
            uiImage.gameObject.SetActive(true);
            Debug.Log("激活UI图像");

            // 启动协程以延迟关闭UI图像
            StartCoroutine(CloseUIImageAfterDelay());
        }
        else
        {
            Debug.LogWarning("没有找到UI图像");
        }
    }

    // 协程：延迟关闭UI图像
    IEnumerator CloseUIImageAfterDelay()
    {
        // 等待1秒钟
        yield return new WaitForSeconds(1f);

        // 关闭UI图像
        if (uiImage != null)
        {
            uiImage.gameObject.SetActive(false);
            Debug.Log("关闭UI图像");
        }
    }
}
