using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suanzhu : MonoBehaviour
{
    private float moveDistance = 2;
    private bool hasMoved = false;       // 是否已经被移动过
    public List<GameObject> gameObjects;
    public bool HasMoved
    {
        get { return hasMoved; }
        set { hasMoved = value; }
    }
    public float MoveDistance
    {
        get { return moveDistance; }
        set { moveDistance = value; }
    }
}
