using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
public Transform player;
public float yOffset = 0.5f; // 相机跟随时y轴的偏移量

private Camera mainCamera;
private float halfCameraHeight;

void Start()
{
    mainCamera = Camera.main;
    halfCameraHeight = mainCamera.orthographicSize * 16; 
}

void Update()
{
    SetPos();
}

void SetPos()
{
    float targetY = transform.position.y; // 默认为相机当前的y轴位置

    if (player.position.y > transform.position.y + halfCameraHeight * yOffset)
    {
        // 如果玩家的y位置超过相机视野的一半，将相机的目标y位置设置为玩家的y位置
        targetY = player.position.y - halfCameraHeight * yOffset;
    }

    // 设置相机位置
    transform.position = new Vector3(player.position.x + 1, targetY, transform.position.z);
}
}