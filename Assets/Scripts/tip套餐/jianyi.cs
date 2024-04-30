using UnityEngine;
using UnityEngine.UI;

public class jianyi : MonoBehaviour
{
    public Button tip;
    void Start()
    {
        tip.interactable = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jianyi")) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

            tip.interactable = true;
        }
    }
}

