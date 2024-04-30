using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 手机摇杆控制 : MonoBehaviour
{
    public GameObject[] 摇杆及圆盘;
    public RectTransform 摇杆;
    public Vector3 摇杆原始位置;
    public Vector3 摇杆当前位置;
    public static Vector3 方向操作;
    public Animator anim;
    public float 移动速度 = 0.06f;

    public void 隐藏或显示摇杆(bool 显示)
    {
        foreach (GameObject fFor in 摇杆及圆盘)
        {
            fFor.SetActive(显示);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        隐藏或显示摇杆(false);
        摇杆当前位置 = 摇杆原始位置 = 摇杆.position;
        
    }

    void Update()
    {
        // 循环检查所有触摸
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(0); // 获取触摸

            // 检测触摸位置是否在屏幕左侧
            if (touch.position.x < Screen.width * 0.5f)
            {
                // 触摸在屏幕左侧，激活手机摇杆功能
                手机摇杆();
            }
            else
            {
                // 触摸在屏幕右侧，禁用手机摇杆功能
                隐藏或显示摇杆(false);
                anim.SetBool("isrunning",false);
            }
        }
         transform.Translate(Vector3.right*手机摇杆控制.方向操作.x *移动速度);
    }

    public void 手机摇杆()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(0); // 获取触摸

            // 检测触摸的位置是否在屏幕左侧，并且触摸阶段为Began（开始触摸）
            if (touch.position.x < Screen.width * 0.6f && touch.phase == TouchPhase.Began)
            {
                隐藏或显示摇杆(true);
                anim.SetBool("isrunning",true);

                // 设置摇杆位置为触摸位置
                foreach (GameObject fFor in 摇杆及圆盘)
                {
                    fFor.transform.position = touch.position;
                }

                摇杆当前位置 = 摇杆原始位置 = 摇杆.position;
            }

            // 更新摇杆当前位置
            摇杆当前位置 = touch.position;

            // 当触摸结束时隐藏摇杆
            if (touch.phase == TouchPhase.Ended)
            {
                摇杆当前位置 = 摇杆原始位置;
                隐藏或显示摇杆(false);
                anim.SetBool("isrunning",false);
            }
        }

        // 计算摇杆方向操作
        方向操作 = (摇杆当前位置 - 摇杆原始位置).normalized;

        // 如果摇杆移动距离超过屏幕高度的10%，则限制摇杆移动范围
        if (Vector3.Distance(摇杆当前位置, 摇杆原始位置) >= Screen.height * 0.1f)
        {
            摇杆当前位置 = 摇杆原始位置 + 方向操作 * 100;
        }

        // 更新摇杆位置
        摇杆.position = 摇杆当前位置;
        
        //转身
        if (方向操作.x > 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            方向操作.x = -1;
        }
        else if (方向操作.x < 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
