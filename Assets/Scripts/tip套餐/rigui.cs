using UnityEngine;
using UnityEngine.UI;

public class rigui : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shu")) 
        {
            Debug.Log("已碰撞");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

        }
    }
}

