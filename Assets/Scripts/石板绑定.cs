using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 石板绑定 : MonoBehaviour
{
    public GameObject targetObject; // 用于指定要检测碰撞的对象

    private void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞对象是否为指定的目标对象
        if (collision.gameObject == targetObject)
        {
            // 如果玩家没有其他脚本被启用，则让石头成为玩家的子物体
            //if (!ArePlayerScriptsEnabled(collision.gameObject))
            //{
                transform.parent = collision.transform;
            //}
        }
    }

    /*
    private bool ArePlayerScriptsEnabled(GameObject player)
    {
        // 获取玩家对象上的所有脚本
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        // 检查所有脚本是否启用
        foreach (MonoBehaviour script in scripts)
        {
            // 排除当前脚本（MoveTogether）以及非自身脚本
            if (script != this && script.enabled)
            {
                return true;
            }
        }

        // 所有脚本都未启用
        return false;
    }*/
}
