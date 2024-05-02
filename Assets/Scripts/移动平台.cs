using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 移动平台 : MonoBehaviour
{
    public Transform 初始位置; 
    public Transform 终止位置;
    public float speed = 2.5f;

    private Vector3 目标位置;

    // Start is called before the first frame update
    void Start()
    {
        目标位置 = 初始位置.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (目标位置 - transform.position).normalized;
        float distance = speed * Time.deltaTime;

        transform.Translate(direction * distance);

        if (Vector3.Distance(transform.position, 目标位置) < 0.05f)
        {
            if (目标位置 == 初始位置.position)
            {
                目标位置 = 终止位置.position;
            }
            else
            {
                目标位置 = 初始位置.position;
            }
        }
    }
}


