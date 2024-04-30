using UnityEngine;
using UnityEngine.UI;

public class UI面板 : MonoBehaviour
{
    public Image uiImage;  // 引用UI Image
    public GameObject playerGameObject;  // Player的GameObject

    void Update()
    {
        // 检查UI Image是否显示
        if (uiImage != null && uiImage.gameObject.activeSelf)
        {
            // 禁用Player的GameObject
            if (playerGameObject != null)
            {
                playerGameObject.SetActive(false);
            }
        }
        else
        {
            // 启用Player的GameObject
            if (playerGameObject != null)
            {
                playerGameObject.SetActive(true);
            }
        }
    }
}
