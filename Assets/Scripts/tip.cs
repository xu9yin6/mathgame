using UnityEngine;
using UnityEngine.UI;

public class tip : MonoBehaviour
{
    public Button button; // UI按钮
    public GameObject imageToToggle; // 切换可见性的图像
    private bool isImageVisible = false; // 用于跟踪图像是否可见

    void Start()
    {
        // 按钮点击事件监听器
        button.onClick.AddListener(ToggleImageVisibility);
        // 初始化隐藏图像
        imageToToggle.SetActive(false);
    }

    public void ToggleImageVisibility()
    {
        // 切换图像可见性状态
        isImageVisible = !isImageVisible;
        // 设置图像的可见性
        imageToToggle.SetActive(isImageVisible);
    }
}
