using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 死亡区域 : MonoBehaviour
{
    [SerializeField] private Vector2 startpos;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("diearea"))
        {
            Debug.Log("有碰撞");
            player.transform.position = startpos;
        }
    }

    
}
