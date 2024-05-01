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
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, 玩家.position.x, ref xSpeed, smoothTime), transform.position.y, transform.position.z);
            if(Mathf.Abs(transform.position.x - 玩家.position.x) < 0.05f)
            {
                isFollow = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(new Vector3(followSpace + transform.position.x, 5, 0),new Vector3(followSpace +transform.position.x, -5, 0));
        Debug.DrawLine(new Vector3(-followSpace + transform.position.x, 5, 0),new Vector3(-followSpace +transform.position.x, -5, 0));

    }
}
