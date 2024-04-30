using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI跟随人物 : MonoBehaviour
{
    public Camera MainCamera;
    public Transform 人物;
    public Vector3 offset;

    void Update()
    {
        if(人物 == null)
        {
            return;
        }
        

        transform.position = MainCamera.WorldToScreenPoint(人物.position + offset);
    }
}