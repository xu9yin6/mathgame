using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 相机阻尼 : MonoBehaviour
{
    bool isFollow;
    float distance;
    float xSpeed = 0.0f;

    public float smoothTime = 0.3f;
    public float followSpace = 1.0f;
    public Transform 玩家;
    public Camera mainCamera;
    [SerializeField] private Transform suanPan;
    
    public float leftBoundary = -5.0f; // 左边界世界坐标值
    public float rightBoundary = 5.0f; // 右边界世界坐标值

    private void FixedUpdate()
    {
        suanPan.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 0.27f, Screen.height * 0.5f, 10f));
        distance = Mathf.Abs(玩家.position.x - transform.position.x);
        if(distance > followSpace)
        {
            isFollow = true;
        }
        if(isFollow)
        {
            float targetX = Mathf.Clamp(玩家.position.x, leftBoundary, rightBoundary); // 限制相机在边界范围内移动
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, targetX, ref xSpeed, smoothTime), transform.position.y, transform.position.z);
            if(Mathf.Abs(transform.position.x - 玩家.position.x) < 0.05f)
            {
                isFollow = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(new Vector3(rightBoundary, 5, 0), new Vector3(rightBoundary, -5, 0)); // 绘制右边界线
        Debug.DrawLine(new Vector3(leftBoundary, 5, 0), new Vector3(leftBoundary, -5, 0)); // 绘制左边界线
    }
}
