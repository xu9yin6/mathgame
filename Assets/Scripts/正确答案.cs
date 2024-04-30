using UnityEngine;
using UnityEngine.UI;

public class 正确答案 : MonoBehaviour
{
    public Image uiImage;  // 引用要关闭的UI图像

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
            // 关闭UI图像
            uiImage.gameObject.SetActive(false);
            Debug.Log("关闭UI图像");
        }
        else
        {
            Debug.LogWarning("没有找到UI图像");
        }
    }
}
